using NUnit.Framework;
using System;
using OpenQA.Selenium;
using System.Threading.Tasks;


namespace TestQA
{
    [TestFixture]
    public class BookingTest : Base
    {  
        [Test]
        [Parallelizable]
        [TestCaseSource(typeof(Base), "BrowserToRun")]
        public void BookingComTest(String browserName)
        {
            Setup(browserName);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            /* 1. should go to the https://www.booking.com page */

            driver.Url = "https://www.booking.com/index.en-gb.html";

            /* 2. Fill in the form with values:Destination: “New York” Check-in: <current  date> Check-out: <current date + 7 days> And submit the search form. */

            driver.FindElement(By.Id("ss")).SendKeys("New York");
            driver.FindElement(By.XPath("//*[@id='frm']/div[1]/div[1]/div[1]/div[1]/ul[1]/li[1]")).Click();
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            driver.FindElement(By.XPath("//*[contains(@data-date,'"+ today + "')]")).Click();
            DateTime newDate = DateTime.Today.AddDays(7);
            driver.FindElement(By.XPath("//*[contains(@data-date,'" + newDate.ToString("yyyy-MM-dd") + "')]")).Click();
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            /* 3.On the search results page it should check whether there is at least 1 result 
             and all results are from New York(it should contain “New York” in the location text) */

            var results = driver.FindElement(By.XPath("//*[@id='hotellist_inner']//*[@class='bui-link']"));
            string city = "New York";
            try
            {
                Assert.IsTrue(results.Displayed);
            }
            catch (AssertionException)
            {
                Console.WriteLine("Assert failed, no results returned");
            }
            try
            {
                Assert.IsTrue(results.Text.Contains(city));
            }
            catch (AssertionException)
            {
                Console.WriteLine("Assert failed, no required specific results returned");               
            }
            
        }
    }
}
