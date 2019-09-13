using SakkeFutbol.Data;
using SakkeFutbol.Models;
using SakkeFutbol.Views;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SakkeFutbol
{
    public partial class App : Application
    {
        static TokenDataBaseController tokenDatabase;
        static UserDataBaseController userDatabase;
        static SettingsDatabaseController settingsDatabase;

        static RestService restService;
        static Label labelScreen;
        private static bool hasInternet;
        private static Page currentPage;
        private static Timer timer;
        private static bool noInterShow;

        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
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


        public static UserDataBaseController UserDataBase
        {
            get
            {
                if (userDatabase == null)
                {
                    userDatabase = new UserDataBaseController();
                }
                return userDatabase;
            }
        }

        public static TokenDataBaseController TokenDataBase
        {
            get
            {
                if (tokenDatabase == null)
                {
                    tokenDatabase = new TokenDataBaseController();
                }
                return tokenDatabase;
            }
        }

        public static SettingsDatabaseController SettingsDatabase
        {
            get
            {
                if (settingsDatabase == null)
                {
                    settingsDatabase = new SettingsDatabaseController();
                }
                return settingsDatabase;
            }
        }

        public static RestService RestService
        {
            get
            {
                if (restService == null)
                {
                    restService = new RestService();
                }
                return restService;
            }
        }

        // --------------- Internet Connection ------------

        public static void StartCheckIfInternet(Label label, Page page)
        {
            labelScreen = label;
            label.Text = Constants.NoInternetText;
            label.IsVisible = false;
            hasInternet = true;
            currentPage = page;
            if (timer == null)
            {
                timer = new Timer((e) =>
                {
                    CheckIfInternetOverTime();
                }, null, 10, (int)TimeSpan.FromSeconds(3).TotalMilliseconds);
            }

        }

        private static void CheckIfInternetOverTime()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            if (!networkConnection.IsConnected)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (hasInternet)
                    {
                        if (!noInterShow)
                        {
                            hasInternet = false;
                            labelScreen.IsVisible = true;
                            await ShowDisplayAlert();
                        }
                    }
                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    hasInternet = true;
                    labelScreen.IsVisible = false;
                });
            }
        }

        public static async Task<bool> CheckIfInternet()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            return networkConnection.IsConnected;

        }

        public static async Task<bool> CheckIfInternetAlertAsync()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            if (!networkConnection.IsConnected)
            {
                if (!noInterShow)
                {
                    await ShowDisplayAlert();
                }
                return false;
            }
            return true;
        }

        private static async Task ShowDisplayAlert()
        {
            noInterShow = false;
            await currentPage.DisplayAlert("Internet", "Device has not Internet, please reconnect.", "Ok");
            noInterShow = false;
        }
    }
}
