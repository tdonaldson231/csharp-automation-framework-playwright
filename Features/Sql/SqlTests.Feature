Feature: SQL Score Validation

  # JIRA Ticket: DB-789
  # This feature validates the integrity of stored procedure results and user-specific queries in the database.

  Background:
    Given the database is up and running

  @sql @smoke @regression
  Scenario: Stored procedure returns scores greater than or equal to 70
    # Ensures that the "GetHighScores" stored procedure correctly filters scores
    # Expected: Only scores >= 70 should be returned.
    When the "GetHighScores" stored procedure is executed with minimum score 70
    Then the results should all have scores >= 70

  @sql @regression
  Scenario: Verify specific user and score from query
    # Verifies that user "Ringo" has a valid score in the "results" table.
    # Expected: Ringo's score must be 75 or higher.
    When I query the "results" table
    Then I should find user "Ringo" with score >= 75
