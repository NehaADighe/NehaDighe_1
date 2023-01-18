using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Auto_Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. User can successfully navigate to the site

            string browserName = "Chrome";
            string applicationURL = " https://global.hitachi-solutions.com/";
            IWebDriver driver = null;

            if (browserName.Equals("Firefox"))
            {
                FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\Users\amitd\source\repos\Selenium SetUp files\geckodriver-v0.31.0-win64", "geckodriver.exe");
                service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
                FirefoxProfile fp = new FirefoxProfile();
                fp.SetPreference("dom.webnotifcations.enabled", false);
                FirefoxOptions op = new FirefoxOptions();
                op.Profile = fp;
                driver = new FirefoxDriver(service, op, TimeSpan.FromSeconds(30));

            }
            else if (browserName.Equals("Chrome"))
            {
                driver = new ChromeDriver(@"C:\Users\amitd\source\repos\Selenium SetUp files\chromedriver_win32\");
            }
            else
            {
                driver = new EdgeDriver(@"C:\Users\amitd\source\repos\Selenium SetUp files\edgedriver_win64\");
            }

            driver.Navigate().GoToUrl(applicationURL);
            driver.Manage().Window.Maximize();

            //2. User can successfully search for keywords

            IWebElement search = driver.FindElement(By.Id("open-global-search"));
            search.Click();

            IWebElement find = driver.FindElement(By.Id("site-search-keyword"));
            find.SendKeys("Hitachi");
            driver.FindElement(By.ClassName("search-form-submit")).Click();

            //3. User can successfully open returned search results
            Thread.Sleep(5000);
            IWebElement openResult = driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/p/a"));
            Thread.Sleep(5000);
            openResult.Click();

        }
            
    }
}
