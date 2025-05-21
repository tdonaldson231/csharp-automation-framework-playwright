#!/bin/bash
set -euo pipefail

echo "Running tests with category: $TEST_CATEGORY"

# Run tests and generate .trx results
dotnet test \
  --filter "TestCategory=$TEST_CATEGORY" \
  --logger "trx;LogFileName=test_results.trx" \
  || echo "Tests failed — collecting results anyway."

# Create result directory if not exists
mkdir -p /test-results

# Copy all trx results to shared location
cp -v /app/**/TestResults/*.trx /test-results/ || echo "No .trx files found"

# If you also generate HTML reports, copy them too
cp -v /app/**/Reports/*.html /test-results/ 2>/dev/null || true

