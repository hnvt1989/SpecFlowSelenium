Feature: Add Employee
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@AddEmployeeNoDiscount
Scenario:  Add Employee no Discount
	Given I have logged into the portal
	And I am on the Benefits Dashboard page
	When I select Add Employee
	Then I should be able to enter employee details
	And First name is ‘Jason’
	And Last name is ‘Smith’
	And Number of dependent is 0
	And the employee should save
	And I should see the employee in the table
	And the salary should be 52000
	And the dependent should be 0
	And the gross pay should be 2000
	And the benefit cost should be 38.46
	And the net pay should be 1961.54
