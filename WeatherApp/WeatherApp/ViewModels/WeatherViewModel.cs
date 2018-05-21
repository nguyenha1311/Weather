using System;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public class WeatherViewModel : ViewModelBase {
        #region Properties

        private string _title = string.Empty;
        public string Title {
            get => _title;
            set {
                if(_title != value) {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _temperature = string.Empty;
        public string Temperature {
            get => _temperature;
            set {
                if(_temperature != value) {
                    _temperature = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _wind = string.Empty;
        public string Wind {
            get => _wind;
            set {
                if(_wind != value) {
                    _wind = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _humidity = string.Empty;
        public string Humidity {
            get => _humidity;
            set {
                if(_humidity != value) {
                    _humidity = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _visibility = string.Empty;
        public string Visibility {
            get => _visibility;
            set {
                if(_visibility != value) {
                    _visibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _sunrise = string.Empty;
        public string Sunrise {
            get => _sunrise;
            set {
                if(_sunrise != value) {
                    _sunrise = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _sunset = string.Empty;
        public string Sunset {
            get => _sunset;
            set {
                if(_sunset != value) {
                    _sunset = value;
                    OnPropertyChanged();
                }
            }
        }
        
        #endregion

        public WeatherViewModel() {
            ResetData();
        }

        /// <summary>
        /// Get weather info by zipCode.
        /// </summary>
        /// <param name="zipCode"> the input zipcode.</param>
        /// <returns>Errors if any errors happened when calling the API or there is no data returned.</returns>

        public async Task<string> GetWeather(string zipCode)
        {
            string queryString = string.Format(Constants.WeatherApiUrl, zipCode, Constants.Key);
            IDataService dataService = new DataService();
            ServiceResult serviceResult =  await dataService.GetDataFromService(queryString).ConfigureAwait(false);

            if(serviceResult != null) {
                if(serviceResult.Results != null) {
                    if(!string.IsNullOrEmpty(serviceResult.Errors)) {
                        ResetData();
                        return serviceResult.Errors;
                    }

                    dynamic results = serviceResult.Results;
                    if(results["weather"] != null) {
                        Title = (string)results["name"];
                        Temperature = (string)results["main"]["temp"] + " F";
                        Wind = (string)results["wind"]["speed"] + " mph";
                        Humidity = (string)results["main"]["humidity"] + " %";
                        Visibility = (string)results["weather"][0]["main"];

                        DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                        DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                        DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                        Sunrise = sunrise.ToString() + " UTC";
                        Sunset = sunset.ToString() + " UTC";
                    }
                } else {
                    ResetData();
                    return "No weather info is found. Please try again later.";
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Reset all data to empty strings.
        /// </summary>
        private void ResetData() {
            Title = string.Empty;
            Wind = string.Empty;
            Temperature = string.Empty;
            Humidity = string.Empty;
            Visibility = string.Empty;
            Sunrise = string.Empty;
            Sunset = string.Empty;
        }
    }
}
