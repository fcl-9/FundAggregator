using System.Collections.Generic;
using FundAggregator.Worker.Shared.ExternalModels;
using FundAggregator.Worker.Shared.Interfaces;
using OpenQA.Selenium;

namespace FundAggregator.Data.HargreavesLansdown.Services
{
    internal class DataExtractorService : IDataExtractorService<IWebDriver>
    {
        public string ExtractFundName(IWebDriver webDriver)
        {
            var fundNameElement = webDriver.FindElement(By.CssSelector("#security-title > h1"));
            return fundNameElement.Text;
        }

        public IList<TopTen> ExtractTopTenGeographies(IWebDriver webDriver)
        {
            var topTenCountries = webDriver.FindElements(By.CssSelector("#top_10_countries_data table tbody > *"));
            var countryContainer = new List<TopTen>();
            foreach (var countryRow in topTenCountries)
            {
                var countryName = countryRow.FindElement(By.CssSelector("td:first-child"));
                var percentage = countryRow.FindElement(By.CssSelector("td:last-child"));
                countryContainer.Add(new TopTen()
                {
                    Name = countryName.GetAttribute("innerHTML"),
                    Percentage = percentage.GetAttribute("innerHTML")
                });
            }
            return countryContainer;
        }

        public IList<TopTen> ExtractTopTenSectors(IWebDriver webDriver)
        {
            var topTenSectors = webDriver.FindElements(By.CssSelector("#top_10_sectors_data table tbody > *"));
            var sectorsContainer = new List<TopTen>();
            foreach (var sectorRow in topTenSectors)
            {
                var sectorName = sectorRow.FindElement(By.CssSelector("td:first-child"));
                var percentage = sectorRow.FindElement(By.CssSelector("td:last-child"));
                sectorsContainer.Add(new TopTen()
                {
                    Name = sectorName.GetAttribute("innerHTML"),
                    Percentage = percentage.GetAttribute("innerHTML")
                });
            }
            return sectorsContainer;
        }
    }
}
