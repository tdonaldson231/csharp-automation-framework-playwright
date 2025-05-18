Feature: Backend Service API

  Background:
    Given the backend is up and operational

  @api @smoke
  Scenario: GET request to a valid endpoint returns 200 OK
    Given the API endpoint is "/objects/5"
    When a GET request is sent to the backend API
    Then the response status code should be "OK"

  @api
  Scenario: GET request to an invalid endpoint returns 404 Not Found
    Given the API endpoint is "/unknown"
    When a GET request is sent to the backend API
    Then the response status code should be "NotFound"

