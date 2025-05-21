#!/bin/bash
set -e

echo "Running tests with category: $TEST_CATEGORY"

dotnet test \
  --filter "TestCategory=$TEST_CATEGORY" \
  --logger "trx;LogFileName=test_results.trx"

mkdir -p /test-results
cp /app/TestResults/*.trx /test-results/
