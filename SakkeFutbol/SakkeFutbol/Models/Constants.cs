using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SakkeFutbol.Models
{
    public class Constants
    {
        public static Boolean IsDev = true;
        public static Color BackgroundColor = Color.FromRgb(58,153,215);
        public static Color MainTextColor = Color.White;

        public static int LoginIconHeight = 120;

        //---------------Login -------------
        public static string LoginUrl = "http://SakkeFutbol.com/Api/Auth/Login";
        public static string NoInternetText = "No Internet, please reconect.";

        public static string SettingsScreenTitle = "Settings";
    }
}
