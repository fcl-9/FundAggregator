using System;
using FundAggregator.Data.HargreavesLansdown.Enum;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace FundAggregator.Data.HargreavesLansdown.Factories
{
    internal class WebDriverFactory
    {
        public static IWebDriver Create(DriverType driverType)
        {
            IWebDriver webDriver;
            switch (driverType)
            {
                case DriverType.GoogleChrome:
                    webDriver = new ChromeDriver();
                    break;
                case DriverType.Firefox:
                    webDriver = new FirefoxDriver();
                    break;
                default:
                    webDriver = new ChromeDriver();
                    break;
            }
            return webDriver;
        }
    }
}