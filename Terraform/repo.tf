resource "google_sourcerepo_repository" "rewards-customer-hub" {
  name = var.repository_name

  depends_on = [
    google_project_service.source_repo,
  ]
}

resource "google_cloudbuild_trigger" "trigger" {
  trigger_template {
    branch_name = "master"
    repo_name   =  google_sourcerepo_repository.rewards-customer-hub.name
  }

  filename = "cloudbuild.yaml"
}