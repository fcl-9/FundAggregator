using System;
using FundAggregator.Worker.Shared.Interfaces;
using OpenQA.Selenium;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FundAggregator.Data.HargreavesLansdown.Services
{
    internal class DataPullingService : IDataPullingService
    {
        private const string Website = "https://www.hl.co.uk/search";
        private readonly IWebDriver _webDriver;
        private readonly IDataExtractorService<IWebDriver> _dataExtraction;

        public DataPullingService(IWebDriver webDriver, IDataExtractorService<IWebDriver> dataExtraction)
        {
            webDriver.Url = Website;
            _webDriver = webDriver;
            _dataExtraction = dataExtraction;
        }

        public void GetFundData(string fundIdentifier)
        {
            _webDriver.Navigate();
            var fundUrl = SearchByFundIdentifier(fundIdentifier);
            _webDriver.Url = fundUrl;
            _webDriver.Navigate();
            _dataExtraction.ExtractFundName(_webDriver);
            _dataExtraction.ExtractTopTenGeographies(_webDriver);
            _dataExtraction.ExtractTopTenSectors(_webDriver);
        }

        public string SearchByFundIdentifier(string fundIdentifier)
        {
            var inputBox = _webDriver.FindElement(By.ClassName("searchBar__input"));
            var searchButton = _webDriver.FindElement(By.ClassName("searchBar__submit"));
            
            inputBox.SendKeys(fundIdentifier);
            searchButton.Click();
            Thread.Sleep(2000);


            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.ClassName("result__link")));


            var redirectUrl = _webDriver.FindElement(By.ClassName("result__link"));
            while (redirectUrl == null)
            {
                //TODO USE Poly to timeout
                redirectUrl = _webDriver.FindElement(By.CssSelector("result > result__title"));
            }

            return redirectUrl.GetAttribute("href");
        }


    }
}