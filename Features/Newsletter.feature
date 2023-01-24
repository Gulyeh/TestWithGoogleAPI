Feature: Newsletter

@Newsletter
Scenario: Subscribe and unsubscribe to newsletter
	# --- Commented auto google auth since there are problems with auth if browser is controlled by testing tool (google changed policy) but code works ---

	# Given I form google auth URL and save as 'googleAuthUrl'
	# And I navigate to url saved as 'googleAuthUrl'
	# And I enter google email address in authorization window
	# And I click Next button on google login page
	# And I enter google account password in authorization window
	# And I click Next button on google password page
	# And I click Advanced button on warning page
	# And I click Open app button on warning page
	# And I click Next button on google access page
	# And I save url parameter 'code' as 'authorizationCode'
	# And I send POST request to google token url with code saved as 'authorizationCode' and save access token from response as 'accessToken'
	Given I send GET request to Gmail Messages API with access token saved as 'accessToken' and save email ID from response as 'latestEmailId'
	When I navigate to url
	And I accept cookies
	Then Main page is opened
	When I click Newsletters button
	Then Newsletters page is opened
	When I choose random newsletter
	And I click Select This Newsletter button
	Then An email form appeared at the bottom of the page
	When I enter email to newsletter form
	And I click Submit button at newsletter form
	And I wait for subscription form to appear
	And I get access_token saved as 'accessToken' and every 1 seconds I try up to 10 seconds to find different email Id than saved as 'latestEmailId' and save new one as 'newLatestEmailId' if found
	Then I check if older email Id saved as 'latestEmailId' is different from newer Id saved as 'newLatestEmailId' and override older with newer
	When I send GET request to Gmail Messages API with access token saved as 'accessToken' and Id saved as 'latestEmailId' and save response body as 'emailBody'
	And I convert email body saved as 'emailBody' from Base to HTML and save as 'emailBody'
	And I find confirmation link in body saved as 'emailBody' and save as 'confirmationLink'
	And I navigate to url saved as 'confirmationLink'
	Then A page with a message about successful subscription confirmation is opened
	When I click Back to the site button
	Then Main page is opened
	When I click Newsletters button
	Then Newsletters page is opened
	When I click See preview button on the same newsletter
	Then A preview page is opened
	When I follow link to unsubscribe from newsletter
	Then Unsubscribe page is opened
	When I enter email address in unsubscribe text field
	And I click submit button on unsubscribe page
	Then A message that the subscription was canceled appears 
	When I get access_token saved as 'accessToken' and every 1 seconds I try up to 10 seconds to find different email Id than saved as 'latestEmailId' and save new one as 'newLatestEmailId' if found
	Then Email Ids saved as 'latestEmailId' and 'newLatestEmailId' are equal


