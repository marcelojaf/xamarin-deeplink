using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinDeepLink.Models;

namespace XamarinDeepLink
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.Title = App.AppName;
            lstCountries.ItemsSource = App.countryList;
        }

        private void lstCountries_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;
            ((ListView)sender).SelectedItem = null;
            Navigation.PushAsync(new CountryDetail(e.Item as Country));
        }
    }
}
