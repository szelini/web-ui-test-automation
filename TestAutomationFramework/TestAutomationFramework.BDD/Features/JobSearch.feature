Feature: JobSearch

Search for jobs based on the set criteria.

@smoke
Scenario Outline: Search for positions based on programming language, location, and remote option.  
	Given I open Epam website
	And I click Careers link
	When I enter '<programming_language>' in Keyword field
	And I select '<location>' in Location dropdown
	And I select Remote checkbox
	And I click Find button
	And I click View and apply button of the latest element in the list of results
	Then '<programming_language>' should be mentioned on the page

Examples:
	| programming_language | location      |
	| C#                   | All Locations |
