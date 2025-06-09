Feature: User Journey 3

  # JIRA Story: journey-233
  # This feature tests the user journey for forms, wigets, and interactions.

  Background:
    Given the user is on the home page

  @journey3 @journeys @regression
  Scenario: Complete Journey 3 Flow
    When the user accesses the forms page
    When the user navigates to the widgets page
    When the user navigates to the interactions page
    Then the user journey has completed successfully
