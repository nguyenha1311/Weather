using System;
using Weather.Models;
using Weather.ViewModels;
using Xamarin.Forms;

namespace Weather.Views
{
    public partial class WeatherPage : ContentPage {

        private WeatherViewModel _weatherViewModel;
        public WeatherPage()
        {
            InitializeComponent();
            _weatherViewModel = new WeatherViewModel();

            //Set the default binding to a default object
            BindingContext = _weatherViewModel = new WeatherViewModel();
        }

        private async void GetWeatherBtn_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(zipCodeEntry.Text)) {
                if(zipCodeEntry.Text.Length != 5) {
                    await DisplayAlert("Error", "Zip Code is invalid", "OK");
                } else {
                    string errors = await _weatherViewModel.GetWeather(zipCodeEntry.Text);

                    if(!string.IsNullOrEmpty(errors)) {
                        await DisplayAlert("", errors, "OK");
                    }
                }

                getWeatherBtn.Text = "Search Again";
            } else {
                await DisplayAlert("Error", "Please enter a zip code", "OK");
            }
        }
    }
}
