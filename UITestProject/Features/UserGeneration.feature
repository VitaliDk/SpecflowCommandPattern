Feature: UserGeneration
   I can create users

@mytag
Scenario: I can add a new user
	Given I have a token
	Then a dmi user is created
	Then go to dmi

