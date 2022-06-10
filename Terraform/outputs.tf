output "wx-api-rewards-customer-hub_http_url" {
  value = module.cloud_run_wx_api_rewards_customer_hub.url
}

output "repo_url" {
  value = google_sourcerepo_repository.repo.url
}
