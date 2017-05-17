Feature: Substraction

Background: 
	Given that the app is installed 

@Substraction
Scenario: Verify Positive Result Substraction 1
	Given I have entered 70 into the calculator as argument 1
	And I have entered 50 into the calculator as argument 2
	When I press minus
	Then the result should be 20 on the screen

@Substraction
Scenario: Verify Positive Result Substraction 2
	Given I have entered 70 into the calculator as argument 1
	And I have entered -50 into the calculator as argument 2
	When I press minus
	Then the result should be 120 on the screen

@Substraction
Scenario: Verify Positive Result Substraction 3
	Given I have entered -50 into the calculator as argument 1
	And I have entered 70 into the calculator as argument 2
	When I press minus
	Then the result should be 20 on the screen

@Substraction
Scenario: Verify Negative Result Substraction 1
	Given I have entered -70 into the calculator as argument 1
	And I have entered -50 into the calculator as argument 2
	When I press minus
	Then the result should be -20 on the screen

@Substraction
Scenario: Verify Negative Result Substraction 2
	Given I have entered 50 into the calculator as argument 1
	And I have entered 70 into the calculator as argument 2
	When I press minus
	Then the result should be -20 on the screen

@Substraction
Scenario: Verify Negative Result Substraction 3
	Given I have entered -70 into the calculator as argument 1
	And I have entered 50 into the calculator as argument 2
	When I press minus
	Then the result should be -20 on the screen

@Substraction
Scenario: Verify Fraction Result Substraction 
	Given I have entered 70.8 into the calculator as argument 1
	And I have entered 50.5 into the calculator as argument 2
	When I press minus
	Then the result should be 20.3 on the screen
