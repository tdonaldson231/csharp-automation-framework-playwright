Feature: SQL Score Validation

  Background:
    Given the database is up and running

  @sql @smoke
  Scenario: Stored procedure returns scores greater than or equal to 70
    When the "GetHighScores" stored procedure is executed with minimum score 70
    Then the results should all have scores >= 70

  @sql
  Scenario: Verify specific user and score from query
    When I query the "results" table
    Then I should find user "Ringo" with score >= 75

