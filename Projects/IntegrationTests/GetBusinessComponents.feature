Feature: GetBusinessComponents
	In order to interact with Business Components
	As a business owner
	I want to be able to get all of the business components

@GetBusinessComponents
Scenario: Get all business components
	Given the following business components
	| StartDateTimeOffset | StopDateTimeOffset |
	| 01/01/2016          | 12/31/2016         |
	| 12/31/2015          | 12/30/2016         |
	When GET is invoked on the business components api
	Then the business components should be returned

@GetBusinessComponents
Scenario: Get a business component by id
	Given the following business components
	| StartDateTimeOffset | StopDateTimeOffset |
	| 01/01/2016          | 12/31/2016         |
	When GET is invoked on the business components api with a specified id
	Then the business component should be returned

@GetBusinessComponents
Scenario: Attempt to get a business component with an invalid id
	Given the following invalid business component id -1
	When GET is invoked on the business components api with a specified id
	Then the exception message should contain the status code 404