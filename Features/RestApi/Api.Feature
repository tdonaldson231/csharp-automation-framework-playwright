Feature: Backend Service API

  # JIRA Ticket: API-1234
  # This feature tests the backend service API responses for various endpoints.

  Background:
    Given the backend is up and operational

  @api
  Scenario: GET request to a valid endpoint returns 200 OK
    # Validates that a GET request to an existing object returns a successful response.
    Given the API endpoint is "/objects/5"
    When a GET request is sent to the backend API
    Then the response status code should be "OK"

  @api
  Scenario: GET request to an invalid endpoint returns 404 Not Found
    # Ensures that an invalid endpoint returns a 404 Not Found error.
    Given the API endpoint is "/unknown"
    When a GET request is sent to the backend API
    Then the response status code should be "NotFound"
