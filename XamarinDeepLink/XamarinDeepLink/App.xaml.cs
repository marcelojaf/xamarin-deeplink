using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinDeepLink.Models;

namespace XamarinDeepLink
{
    public partial class App : Application
    {
        public static string AppName = "XamCountries";
        public static string AppUrl = "https://xamcountries.com/country/{0}";
        public static List<Country> countryList = new List<Country>
            {
                new Country{ Id = 1, Name = "Xam-Argentina", ViewColor = Color.LightBlue, FontColor = Color.White },
                new Country{ Id = 2, Name = "Xam-Brazil", ViewColor = Color.Yellow, FontColor = Color.Green },
                new Country{ Id = 3, Name = "Xam-Canada", ViewColor = Color.Red, FontColor = Color.White },
                new Country{ Id = 4, Name = "Xam-France", ViewColor = Color.Blue, FontColor = Color.Red },
                new Country{ Id = 5, Name = "Xam-Spain", ViewColor = Color.Red, FontColor = Color.Yellow }
            };

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new XamarinDeepLink.MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void OnAppLinkRequestReceived(Uri uri)
        {
            base.OnAppLinkRequestReceived(uri);

            var query = uri.PathAndQuery.Trim(new[] { '/' });
            var matchedItem = countryList.FirstOrDefault(x => query.EndsWith(x.Id.ToString(), StringComparison.OrdinalIgnoreCase));
            if (matchedItem != null)
            {
                MainPage.Navigation.PushAsync(new CountryDetail(matchedItem));
            }
        }
    }
}
