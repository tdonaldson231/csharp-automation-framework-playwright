@Smoke @FormTests
Feature: Forms
  Scenario: Submit Form
    Given the user navigates to the form page
    When they enter a name, message and submit
    Then the from is processed with a thank you message
