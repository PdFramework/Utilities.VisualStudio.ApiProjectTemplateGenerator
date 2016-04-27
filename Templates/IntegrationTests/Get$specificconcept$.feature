Feature: Get$specificconcept$
	In order to interact with $humanizedspecificconcept$
	As a business owner
	I want to be able to get all of the $humanizedspecificconcept$

@Get$specificconcept$
Scenario: Get all $humanizedspecificconcept$
	Given the following $humanizedspecificconcept$
	| StartDateTimeOffset | StopDateTimeOffset |
	| 01/01/2016          | 12/31/2016         |
	| 12/31/2015          | 12/30/2016         |
	When GET is invoked on the $humanizedspecificconcept$ api
	Then the $humanizedspecificconcept$ should be returned

@Get$specificconcept$
Scenario: Get a $humanizedspecificconceptsingularized$ by id
	Given the following $humanizedspecificconcept$
	| StartDateTimeOffset | StopDateTimeOffset |
	| 01/01/2016          | 12/31/2016         |
	When GET is invoked on the $humanizedspecificconcept$ api with a specified id
	Then the $humanizedspecificconceptsingularized$ should be returned

@Get$specificconcept$
Scenario: Attempt to get a $humanizedspecificconceptsingularized$ with an invalid id
	Given the following invalid $humanizedspecificconceptsingularized$ id -1
	When GET is invoked on the $humanizedspecificconcept$ api with a specified id
	Then the exception message should contain the status code 404