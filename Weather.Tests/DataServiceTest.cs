using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Weather.Models;
using Weather.Services;

namespace Weather.Tests
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        [Description("Test getting data from the weather API")]
        public async Task GetDataFromServiceTest() {
            const string zipCode = "75007";

            string queryString = string.Format(Constants.WeatherApiUrl, zipCode, Constants.Key);
            IDataService dataService = new DataService();
            ServiceResult serviceResult = await dataService.GetDataFromService(queryString).ConfigureAwait(false);

            Assert.IsNotNull(serviceResult);
            Assert.IsNotNull(serviceResult.Results);
            Assert.IsTrue(string.IsNullOrEmpty(serviceResult.Errors));

            dynamic results = serviceResult.Results;
            Assert.IsTrue(results["weather"] != null);
            Assert.IsFalse(string.IsNullOrEmpty(results["name"].ToString()));
            Assert.IsFalse(string.IsNullOrEmpty(results["main"]["temp"].ToString()));
            Assert.IsFalse(string.IsNullOrEmpty(results["wind"]["speed"].ToString()));
            Assert.IsFalse(string.IsNullOrEmpty(results["main"]["humidity"].ToString()));
            Assert.IsFalse(string.IsNullOrEmpty(results["weather"][0]["main"].ToString()));
            Assert.IsFalse(string.IsNullOrEmpty(results["sys"]["sunrise"].ToString()));
            Assert.IsFalse(string.IsNullOrEmpty(results["sys"]["sunset"].ToString()));
            Assert.AreEqual(results["name"].ToString(), "Lewisville");
        }
    }
}
