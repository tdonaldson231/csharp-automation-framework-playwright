#!/bin/bash
dotnet test AutomationFrameworkRepo_v03.sln \
    --settings Tests/RunSettings/"${TEST_ENV}".runsettings \
    --filter "TestCategory=${TEST_CATEGORY}" \
    --logger "trx;LogFileName=Tests/Results/test_results.trx"
