Feature: Skills


As a user, I want to Add and Verify Skills

 
@regression
Scenario Outline: Test add and verify multiple skills 
	Given I am on the Sign in page
	When  I enter valid credentials
	Then  I should see the Profile page
	And Clear the data in Skills tab
	And   Add <skill> and <level>
	Then  Findskill added <skill> and <level>

	Examples:
	| skill    | level        |
	| Dance    | Beginner     |
	| @#45Re1  | Intermediate |
	| silambam | Intermediate |
	| karate   | Expert       |
	| song     | Beginner     |
	
@regression
Scenario Outline: Add and verify duplicate skills and levels
	Given I am on the Sign in page
	When  I enter valid credentials
	Then  I should see the Profile page
	And Clear the data in Skills tab
	And   Add <skill> and <level>
	And   Addsame <skill> and <level> again
	And Verify that duplicate skill and level is not added

	Examples:
	| skill    | level |
	| Dance    | Beginner |	

		@regression
Scenario Outline: Add and verify duplicate skills 
	Given I am on the Sign in page
	When  I enter valid credentials
	Then  I should see the Profile page
	And Clear the data in Skills tab
	And   Add <skill> and <level>
	And   Addsame <skill> and <differentlevel> again
	And Verify that duplicate skill is not added

	Examples:
	| skill     | level  | differentlevel |
	| silambam  | Expert | Beginner       |


	
	@regression
Scenario Outline: Add and verify empty skill and levels
	Given I am on the Sign in page
	When  I enter valid credentials
	Then  I should see the Profile page
	And Clear the data in Skills tab
	And   Add <skill> and <level>
	And Verify that popup appears for empty skill and level

	Examples:
	| skill | level  |
	|		|    	 |


	@regression
Scenario Outline: Delete and verify Skill and levels
	Given I am on the Sign in page
	When  I enter valid credentials
	Then  I should see the Profile page
	And Clear the data in Skills tab
	And   Add <skill> and <level>
	And   Deleteadd <skill> and <level>
	And   Verify Addskill that <skill> and level is deleted

	Examples:
	| skill | level |
	| silambam | Expert|

	@regression
Scenario Outline: Edit and verify skill and levels
	Given I am on the Sign in page
	When  I enter valid credentials
	Then  I should see the Profile page
	And Clear the data in Skills tab
	And   Add <skill> and <level>
	And   Editskill <skill> and <level> to <updatedskill> and <updatedlevel>
	And Verify skill that <updatedskill> and <updatedlevel> is updated

	Examples:
	| skill  | level    | updatedskill | updatedlevel |
	| karate | Beginner | silambam     | Expert        |
		
	
	