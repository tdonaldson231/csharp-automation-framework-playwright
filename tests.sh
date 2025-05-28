#!/usr/bin/env bash
set -euo pipefail

# Default values
TEST_ENV="dev"
TEST_CATEGORY="smoke"

# Parse command-line options
while getopts "e:c:" opt; do
  case "$opt" in
    e) TEST_ENV="$OPTARG" ;;
    c) TEST_CATEGORY="$OPTARG" ;;
    *)
      echo "Usage: $0 [-e environment] [-c test_category]"
      exit 1
      ;;
  esac
done

echo "Running tests in Environment: $TEST_ENV"
echo "Running tests using category: $TEST_CATEGORY"

# Run tests and generate .trx results
dotnet test AutomationFrameworkRepo_v03.sln \
  --filter "TestCategory=$TEST_CATEGORY" \
  --settings "Tests/RunSettings/$TEST_ENV.runsettings" \
  --logger "trx;LogFileName=test_results.trx" \
  #--results-directory "Tests/Results" \
  || echo "Tests failed — collecting results anyway."
