Feature: User Journey 1

  # JIRA Story: journey-231
  # This feature tests the user journey for elements and forms.

  Background:
    Given the user is on the home page

  @journeys @smoke @regression
  Scenario: Complete Journey 1 Flow
    When the user accesses the elements page
    When the user navigates to the forms page
    Then the user journey has completed successfully
