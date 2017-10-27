using Plugin.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinDeepLink.Models;

namespace XamarinDeepLink
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountryDetail : ContentPage
    {
        private Country country;
        private AppLinkEntry _appLink;

        public CountryDetail(Country _country)
        {
            InitializeComponent();

            country = _country;
            this.Title = App.AppName + " - " + country.Name;
            this.BindingContext = country;
            this.BackgroundColor = country.ViewColor;
            this.lblCountry.Text = country.Name;
        }

        private void btnShare_Clicked(object sender, EventArgs e)
        {
            CrossShare.Current.Share(new Plugin.Share.Abstractions.ShareMessage
            {
                Title = "XamCountries - " + country.Name,
                Text = "Check this country with this awesome app!",
                Url = string.Format(App.AppUrl, country.Id)
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _appLink = new AppLinkEntry
            {
                AppLinkUri = new Uri(string.Format(App.AppUrl, country.Id)),
                Description = "Country inside an awesome app!",
                Title = "XamCountries - " + country.Name,
                IsLinkActive = true
            };

            Application.Current.AppLinks.RegisterLink(_appLink);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            //_appLink.IsLinkActive = false;
            //Application.Current.AppLinks.RegisterLink(_appLink);
        }
    }
}