Feature: LanguagesAndSkills

As a user, I want to Add and Verify Languages and Skills

@regression
Scenario: Add and Verify Languages 
	Given I am on the Sign in page
	When  I enter valid credentials
	Then  I should see the Profile page
	And   Add Language and level
	Then Verify added language and level

@regression
Scenario: Add and Verify Skills
	Given I am on the Sign in page
	When  I enter valid credentials
	Then  I should see the Profile page
	And   Add Skills
	Then  Verify added Skills

