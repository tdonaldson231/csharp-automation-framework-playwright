Feature: User Journey 2

  # JIRA Story: journey-232
  # This feature tests the user journey for elements and wigets.

  Background:
    Given the user is on the home page

  @journey2 @journeys @regression
  Scenario: Complete Journey 2 Flow
    When the user accesses the elements page
    When the user navigates to the widgets page
    Then the user journey has completed successfully

