using SakkeFutbol.Models;
using SakkeFutbol.Views.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SakkeFutbol.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Lbl_UserName.TextColor = Constants.MainTextColor;
            Lbl_Password.TextColor = Constants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;
            App.StartCheckIfInternet(lbl_NoInternet, this);


            Entry_UserName.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedure(s, e);
        }

        async void SignInProcedure(object sender, EventArgs e)
        {
            User user = new User(Entry_UserName?.Text, Entry_Password?.Text);
            if (user.CheckInformation())
            {
                ActivitySpinner.IsVisible = true;
                //var result = await App.RestService.Login(user);
                var result = new Token();
                await DisplayAlert("Login", "Login Success", "Ok");

                if (App.SettingsDatabase.GetSettings() == null)
                {
                    Settings settings = new Models.Settings();
                    App.SettingsDatabase.SaveSettings(settings);
                }
                
                if(result != null)
                {
                    ActivitySpinner.IsVisible = false;
                    //App.UserDataBase.SaverUser(user);
                    //App.TokenDataBase.SaveToken(result);
                    //await Navigation.PushAsync(new Dashboard());
                    if (Device.RuntimePlatform == Device.Android)
                    {
                        Application.Current.MainPage = new NavigationPage(new MasterDetail());
                    }
                    else if (Device.RuntimePlatform == Device.iOS)
                    {
                        await Navigation.PushModalAsync(new NavigationPage(new MasterDetail()));
                    }
                }
            }
            else
            {
                await DisplayAlert("Login", "Login Not Correct, Empty UserName or Password", "Ok");
                ActivitySpinner.IsVisible = false;
            }
        }
    }
}