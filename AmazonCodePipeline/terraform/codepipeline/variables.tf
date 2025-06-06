variable "github_owner" {
  description = "GitHub username or org"
  type        = string
  default = "github.com/tdonaldson231/"
}

variable "codestar_connection_arn" {
  description = "Codestar Connection ARN"
  type        = string
  default = "arn:aws:codeconnections:us-west-2:390844761004:connection/a05afc29-473f-4fd7-a255-5fa4d37bffd7"  
}

variable "github_token" {
  description = "GitHub OAuth token"
  type        = string
  sensitive   = true
}

variable "github_full_repository_id" {
    description = "GitHub Repo"
    type = string
    default = "tdonaldson231/csharp-automation-framework-playwright" 
}

variable "github_repo_url" {
    description = "GitHub Repo URL"
    type = string
    default = "https://github.com/tdonaldson231/csharp-automation-framework-playwright.git" 
}

variable "github_branch" {
  description = "GitHub Branch"
  type = string
  default = "aws-pipeline-terraform" ##"main"
}

variable "test_environment" {
  description = "Test Environment"
  type = string
  default = "dev"
}

variable "test_category" {
  description = "Test Category"
  type = string
  default = "smoke"
}

variable "image_name" {
  description = "Docker Image Name"
  type = string
  default = "docker-image"
}

variable "image_tag" {
  description = "Docker Image Tag"
  type = string
  default = "231"
}