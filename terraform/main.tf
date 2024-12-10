terraform {
  required_providers {
    docker = {
      source  = "kreuzwerker/docker"
      version = "~> 3.0"
    }
  }
}

provider "docker" {}

resource "docker_image" "sqlserver" {
  name         = "mcr.microsoft.com/mssql/server:2019-latest"
  keep_locally = true
}

resource "docker_container" "sqlserver" {
  image = docker_image.sqlserver.name
  name  = "sqlserver"
  ports {
    internal = 1433
    external = 1433
  }
  env = [
    "ACCEPT_EULA=Y",
    "SA_PASSWORD=YourStrong!Password"
  ]
}
