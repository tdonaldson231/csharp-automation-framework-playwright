Feature: Mock Service API

  # JIRA Ticket: API-1235
  # This feature tests the backend service API responses for various endpoints.

  Background:
    Given the backend is up and operational

  @mockapi @smoke @regression
  Scenario: GET request to a valid mock endpoint returns 200 OK
    # Validates that a GET request to an existing object returns a successful response.
    Given the Mock API endpoint is "/health"
    When a GET request is sent to the mock API
    Then the mock response status code should be "OK"
