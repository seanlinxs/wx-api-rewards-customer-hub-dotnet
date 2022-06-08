module cloud_run_wx_api_rewards_customer_hub {
  source = "./service"

  project    = var.project
  location   = var.region
  dependency = null_resource.init_docker_images

  name     = "wx-api-rewards-customer-hub"
  protocol = "http"
  auth     = false
}