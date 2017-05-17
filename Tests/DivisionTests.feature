Feature: DivisionTests

Background: 
	Given that the app is installed 

@Division
Scenario: Verify Positive Result Division 
	Given I have entered 120 into the calculator as argument 1
	And I have entered 60 into the calculator as argument 2
	When I press division
	Then the result should be 2 on the screen

@Division
Scenario: Verify Fraction Result Division 
	Given I have entered 60 into the calculator as argument 1
	And I have entered 120 into the calculator as argument 2
	When I press division
	Then the result should be 0.5 on the screen

@Division
Scenario: Verify Negative Result Division 
	Given I have entered -120 into the calculator as argument 1
	And I have entered 60 into the calculator as argument 2
	When I press division
	Then the result should be -2 on the screen


