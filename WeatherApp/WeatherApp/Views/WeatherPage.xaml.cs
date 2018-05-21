using System;
using WeatherApp.Models;
using WeatherApp.ViewModels;
using Xamarin.Forms;

namespace WeatherApp.Views
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
            if (!string.IsNullOrEmpty(zipCodeEntry.Text))
            {
                string errors = await _weatherViewModel.GetWeather(zipCodeEntry.Text);

                if(!string.IsNullOrEmpty(errors)) {
                    await DisplayAlert("", errors, "OK");
                }

                getWeatherBtn.Text = "Search Again";
            }
        }
    }
}
