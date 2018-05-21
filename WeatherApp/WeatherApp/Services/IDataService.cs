using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IDataService {
        /// <summary>
        /// Return data from the Weather API call
        /// </summary>
        /// <param name="url">The API URL with parameters</param>
        /// <returns>data from the API call</returns>
        Task<ServiceResult> GetDataFromService(string url);
    }
}
