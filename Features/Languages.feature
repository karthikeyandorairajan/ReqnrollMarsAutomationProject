Feature: Languages

As a user, I want to Add and Verify Languages 

@regression
Scenario Outline: Test add and verify multiple languages 
	Given I am on the Sign in page
	When  I enter valid credentials
	Then  I should see the Profile page
	Then Clear the data
	And   Enter <language> and <level>
	Then Find added <language> and <level>
	
	Examples:
	| language | level |
	| English  | Basic |
	| French   | Basic |
	| 0@#*~3   | Fluent|
	

@regression
Scenario Outline: Add and verify duplicate languages and levels
	Given I am on the Sign in page
	When  I enter valid credentials
	Then  I should see the Profile page
	Then Clear the data
	And   Enter <language> and <level>
	And   Same <language> and <level> again
	And Verify that duplicate language and level is not added

	Examples:
	| language | level  |
	| English  | Fluent |


	@regression
Scenario Outline: Add and verify duplicate languages 
	Given I am on the Sign in page
	When  I enter valid credentials
	Then  I should see the Profile page
	Then Clear the data
	And   Enter <language> and <level>
	And   Same <language> and <differentlevel> again
	And Verify that duplicate language is not added

	Examples:
	| language | level  | differentlevel |
	| English  | Fluent | Basic          |
		

	@regression
Scenario Outline: Add and verify empty languages and levels
	Given I am on the Sign in page
	When  I enter valid credentials
	Then  I should see the Profile page
	Then Clear the data
	And   Enter <language> and <level>
	And Verify that popup appears for empty language and level

	Examples:
	| language | level  |
	|		   |		|

	@regression
Scenario Outline: Delete and verify languages and levels
	Given I am on the Sign in page
	When  I enter valid credentials
	Then  I should see the Profile page
	Then Clear the data
	And   Enter <language> and <level>
	And   Delete <language> and <level>
	And Verify that <language> and level is deleted

	Examples:
	| language | level |
	| English | Fluent |

	@regression
Scenario Outline: Edit and verify languages and levels
	Given I am on the Sign in page
	When  I enter valid credentials
	Then  I should see the Profile page
	Then Clear the data
	And   Enter <language> and <level>
	And   Edit <language> and <level> to <updatedlanguage> and <updatedlevel>
	And Verify that <updatedlanguage> and <updatedlevel> is updated

	Examples:
	| language | level  | updatedlanguage | updatedlevel |
	| English  | Fluent | Tamil           | Basic        |
		
		

Scenario Outline: Test add and verify maximum languages 
	Given I am on the Sign in page
	When  I enter valid credentials
	Then  I should see the Profile page
	Then Clear the data
	And   Enter <language1> and <level1>  
	And   Enter <language2> and <level2>  
	And   Enter <language3> and <level3>  
	And   Enter <language4> and <level4>  
	Then Verify AddNewbutton is not available
	Examples:
	| language1 | level1  | language2 | level2 | language3 | level3 | language4 | level4 |
	| English   | Basic   | French    | Basic  | 0@#*~3    | Fluent |  1234^&*  | Conversational |
	
		