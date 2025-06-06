resource "aws_codepipeline" "pipeline" {
  name     = "pipeline-test-app-231"
  role_arn = "arn:aws:iam::390844761004:role/service-role/AWSCodePipelineServiceRole-us-west-2-pipeline-test-app-231"

  artifact_store {
    type     = "S3"
    location = "codepipeline-us-west-2-be61d99d8300-40a3-ad41-d017bae94435"
  }

  stage {
    name = "Source"

    action {
      name             = "Source"
      category         = "Source"
      owner            = "AWS"
      provider         = "CodeStarSourceConnection"
      version          = "1"
      output_artifacts = ["SourceArtifact"]
      run_order        = 1

      configuration = {
        ConnectionArn    = var.codestar_connection_arn
        FullRepositoryId = var.github_full_repository_id
        BranchName       = var.github_branch
        DetectChanges    = "true"
      }      
      
      region    = "us-west-2"
      namespace = "SourceVariables"
    }
  }

  stage {
    name = "Build"

    action {
      name             = "Build"
      category         = "Build"
      owner            = "AWS"
      provider         = "CodeBuild"
      version          = "1"
      input_artifacts  = ["SourceArtifact"]
      output_artifacts = ["BuildArtifact"]
      run_order        = 1

      configuration = {
        ProjectName = "build-project-test-app-231"
        EnvironmentVariables = jsonencode([
          {
            name  = "GIT_REPO"
            value = var.github_repo_url
            type  = "PLAINTEXT"
          },
          {
            name  = "GIT_BRANCH"
            value = var.github_branch
            type  = "PLAINTEXT"
          },
          {
            name  = "TEST_ENV"
            value = var.test_environment
            type  = "PLAINTEXT"
          },
          {
            name  = "TEST_CATEGORY"
            value = var.test_category
            type  = "PLAINTEXT"
          },
          {
            name  = "IMAGE_NAME"
            value = var.image_name
            type  = "PLAINTEXT"
          },
          {
            name  = "IMAGE_TAG"
            value = var.image_tag
            type  = "PLAINTEXT"
          },
          {
            name  = "DOCKERHUB_USERNAME"
            value = "dockerhub/credentials:DOCKERHUB_USERNAME"
            type  = "SECRETS_MANAGER"
          },
          {
            name  = "DOCKERHUB_PASSWORD"
            value = "dockerhub/credentials:DOCKERHUB_PASSWORD"
            type  = "SECRETS_MANAGER"
          }
      ])}
      
      region    = "us-west-2"
      namespace = "BuildVariables"
    }
  }

  pipeline_type  = "V2"
  execution_mode = "QUEUED"

  depends_on = [ 
    aws_iam_role_policy.allow_codestar_connection,
    data.aws_secretsmanager_secret.dockerhub_credentials
  ]
}

data "aws_iam_role" "pipeline_role" {
  name = "AWSCodePipelineServiceRole-us-west-2-pipeline-test-app-231"
}

resource "aws_iam_role_policy" "allow_codestar_connection" {
  name = "AllowCodeStarConnectionUse"
  role = data.aws_iam_role.pipeline_role.name

  policy = jsonencode({
    Version = "2012-10-17",
    Statement = [
      {
        Effect   = "Allow",
        Action   = "codestar-connections:UseConnection",
        Resource = var.codestar_connection_arn
      }
    ]
  })
}

data "aws_secretsmanager_secret" "dockerhub_credentials" {
  name = "dockerhub/credentials"
}

resource "aws_iam_role_policy" "codebuild_secrets_policy" {
  name = "AllowSecretsManagerAccess"
  role = "codebuild-build-project-test-app-231-service-role"

  policy = jsonencode({
    Version = "2012-10-17",
    Statement = [
      {
        Effect   = "Allow",
        Action   = [
          "secretsmanager:GetSecretValue"
        ],
        Resource = data.aws_secretsmanager_secret.dockerhub_credentials.arn
      }
    ]
  })
}
