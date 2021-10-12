using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace AutomationTestingProject
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\11035974\Downloads\chromedriver_win32");
            string url = "http://localhost:31273";
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(2000);

            IWebElement element = driver.FindElement(By.Id("5"));
            element.Click();
            Thread.Sleep(2000);
            
            IWebElement button = driver.FindElement(By.Id("buy"));
            button.Click();

            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}
