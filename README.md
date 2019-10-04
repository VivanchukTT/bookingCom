# bookingCom
booking.com Test
To run this test You need connect to the repo, open the progect in your VS (2019) and run the TestQA. This Test will:

1. Go to the https://www.booking.com page
2. Fill in the form with values: 
  Destination: “New York” 
  Check-in: <current date>
  Check-out: <current date + 7 days> 
And submit the search form.
3. On the search results page it will check whether there is at least 1 result and results are from New York 
(it should contain “New York” in the location text)

The test will run in Chrome && FireFox browsers (IE now has an issue with updates incompatible with IE driver) 

Acceptance criteria: As a result of the Test you should see two Tests passed in your Test Explorer - for Chrome and FF browsers.
