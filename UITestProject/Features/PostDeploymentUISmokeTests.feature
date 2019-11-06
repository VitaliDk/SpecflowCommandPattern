Feature: PostDeploymentUISmokeTests
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: User can view an order
   Given the user is logged into the DMI
   When the user navigates to the orders page
   Then the user can see an order

Scenario: user can navigate to the order details page
   Given the user is on the orders page
   When the user can find at least 1 order
   And the user clicks the link to the order details page for an order
   Then the user is taken to the order details page
