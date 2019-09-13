using SakkeFutbol.Models;
using SakkeFutbol.Views.DetailViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SakkeFutbol.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            App.StartCheckIfInternet(lbl_NoInternet, this);

        }
        async void SelectedScreen(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InfoScreen1());
        }

    }
}