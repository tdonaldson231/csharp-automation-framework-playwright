Feature: UI Form Validation

  Background:
    Given the user navigates to the form page

  @ui @smoke @regression
  Scenario: Submit contact form
    When the user enters a name, message and clicks the submit button
    Then the form is processed with a thank you message
