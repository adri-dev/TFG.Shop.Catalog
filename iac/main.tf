provider "azurerm" {
  features {}

  skip_provider_registration = true
}

data "azurerm_resource_group" "rg" {
  name = var.resource_group_name
}

data "azurerm_kubernetes_cluster" "kube" {
  name                = var.cluster_name
  resource_group_name = var.resource_group_name
}

data "azurerm_mssql_server" "sqlserver" {
  name                = var.sql_server_name
  resource_group_name = data.azurerm_resource_group.rg.name
}

provider "kubernetes" {
  host                   = data.azurerm_kubernetes_cluster.kube.kube_config.0.host
  client_certificate     = base64decode(data.azurerm_kubernetes_cluster.kube.kube_config.0.client_certificate)
  client_key             = base64decode(data.azurerm_kubernetes_cluster.kube.kube_config.0.client_key)
  cluster_ca_certificate = base64decode(data.azurerm_kubernetes_cluster.kube.kube_config.0.cluster_ca_certificate)
}

resource "kubernetes_deployment_v1" "deployment" {
  metadata {
    name = "catalog-dply"
  }

  spec {
    selector {
      match_labels = {
        app = "catalog"
      }
    }

    replicas = 1

    template {
      metadata {
        labels = {
          app = "catalog"
        }
      }

      spec {
        container {
          name  = "catalog"
          image = "docker.io/wadrydev/tfgcatalog"
          env {
            name  = "ConnectionStrings__ProductsDb"
            value = "Server=tcp:${data.azurerm_mssql_server.sqlserver.name}.database.windows.net,1433;Initial Catalog=${azurerm_mssql_database.db.name};Persist Security Info=False;User ID=${data.azurerm_mssql_server.sqlserver.administrator_login};Password=${var.SQL_PASSWORD};MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
          }
          port {
            name           = "http"
            container_port = 80
          }
        }
      }
    }
  }
}

resource "kubernetes_service" "svc" {
  metadata {
    name = "catalog-svc"
  }
  spec {
    selector = {
      app = "catalog"
    }
    port {
      protocol    = "TCP"
      port        = 80
      target_port = "http"
    }
  }
}

resource "azurerm_mssql_database" "db" {
  name                = "catalogdb"
  server_id           = data.azurerm_mssql_server.sqlserver.id

  depends_on = [
    data.azurerm_mssql_server.sqlserver
  ]
}
