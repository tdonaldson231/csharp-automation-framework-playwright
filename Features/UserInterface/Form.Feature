Feature: UI Form Validation

  # JIRA Ticket: UI-456
  # This feature validates the functionality of the contact form submission.

  Background:
    Given the user navigates to the form page

  @suite @ui @smoke @regression
  Scenario: Submit contact form
    # Ensures that users can successfully submit the contact form.
    # Expected: A thank you message should be displayed after submission.
    When the user enters a name, message, and clicks the submit button
    Then the form is processed with a thank you message
