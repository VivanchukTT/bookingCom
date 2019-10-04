using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace TestQA
{
    public class Base
    {
        protected IWebDriver driver;
        public void Setup(String browserName)
        {
            if (browserName.Equals("ie"))
            {
                driver = new InternetExplorerDriver();
            }
            else if (browserName.Equals("chrome"))
            {
                driver = new ChromeDriver();
            }
            else if (browserName.Equals("firefox"))
            {
                driver = new FirefoxDriver();
            }
        }


        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }
        public static IEnumerable<String> BrowserToRun()
        {
            String[] browsers = { "chrome", "firefox"};
            foreach (String b in browsers)
            {
                yield return b;
            }
        }
    }
}
