Feature: IdentityProvider
     Testing the identity provider

@mytag
Scenario: A user is able to log into the DMI
	Given the user is on the login page
	When the user attempts to log in
	Then the user is redirected to the DMI

Scenario: A user is able to log out of the DMI
    Given the user is logged into the DMI
	When the user attempts to log out
    Then the user is redirected to the DMI login page

Scenario: User is shown a validation message when attempting to log in with an invalid username
    Given the user is on the login page
	When the user attempts to log in with an invalid username
	Then the user is shown a validation message explaining that their login attempt was unsuccessful
	
Scenario: User is shown a validation message when attempting to log in with an invalid password
    Given the user is on the login page
	When the user attempts to log in with an invalid password
	Then the user is shown a validation message explaining that their login attempt was unsuccessful