using System;
using System.Collections.Generic;
using System.Text;

namespace Weather
{
    public static class Constants {

        /// <summary>
        /// API key at http://openweathermap.org/appid 
        /// </summary>
        public const string  Key = "eee8d86f9b6a9ee4041b4e942896229d";

        /// <summary>
        /// API URL for the above API key 
        /// </summary>
        public const string  WeatherApiUrl = "http://api.openweathermap.org/data/2.5/weather?zip={0},us&appid={1}&units=imperial";       
    }
}
