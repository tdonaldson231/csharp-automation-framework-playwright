#!/bin/bash

dotnet test AutomationFrameworkRepo_v03.sln \
    --settings Tests/RunSettings/"${TEST_ENV}".runsettings \
    --filter "TestCategory=${TEST_CATEGORY}" \
    --logger "trx;LogFileName=test_results.trx"

# After tests finish, copy the generated HTML report to the mounted TestResults folder
cp /app/Reports/ExtentReport_*.html /app/TestResults/