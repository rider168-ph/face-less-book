# Express a test case in the following form:
#    Given <initial condition>
#    When <action>
#    Then <expected result>

Feature: List of Friends
	In order to list my friends
	As an FLB member
	I want to list my friends in alphabetical order either by ascending or descending

@ListAscending
Scenario: List of friends Full Name in ascending order
	Given I am on the Friends screen with the listing in descending order
	When I press the Name column header to sort in ascending order
	Then the result should be the list of Friends in ascending order

@ListDescending
Scenario: List of friends Full Name in descending order 
	Given I am on the Friends screen with the listing in ascending order
	When I press the Name column header to sort in descending order
	Then the result should be the list of Friends in descending order
