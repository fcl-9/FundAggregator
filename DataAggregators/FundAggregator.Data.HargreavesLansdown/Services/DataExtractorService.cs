using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using FundAggregator.Worker.Shared.DataTransferObject;
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

        public string ExtractFundIssuer(IWebDriver webDriver)
        {
            var fundProperties= webDriver.FindElements(By.CssSelector("div.columns.large-6.medium-6.small-12.margin-bottom .factsheet-table tbody tr"));
            foreach (var propertyPair in fundProperties)
            {
                var propertyName = propertyPair.FindElement(By.CssSelector("th"));
                if (propertyName.GetAttribute("innerHTML").Contains("Issuer"))
                {
                    var propertyValue = propertyPair.FindElement(By.CssSelector("td"));
                    return NewLineRemover(propertyValue.GetAttribute("innerHTML"));
                }
            }
            return string.Empty;
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
                    Percentage = ToDecimal(percentage.GetAttribute("innerHTML"))
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
                    Percentage = ToDecimal(percentage.GetAttribute("innerHTML"))
                });
            }
            return sectorsContainer;
        }

        public FundIdentifiers ExtractFundIdentifiers(IWebDriver webDriver, string isin)
        {
            return new FundIdentifiers()
            {
                Apir = string.Empty,
                Isin = isin,
                Sedol = string.Empty
            };
        }

        private decimal ToDecimal(string valueToParse)
        {
            return decimal.Parse(valueToParse.Replace("%", string.Empty));
        }

        private string NewLineRemover(string nonProcessedString)
        {
            var nonWhiteSpaceString = Regex.Replace(nonProcessedString, "\\s\\s+", string.Empty);
            return nonWhiteSpaceString.Replace(System.Environment.NewLine, string.Empty);
        }
    }
}
