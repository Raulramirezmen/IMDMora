using SakkeFutbol.Models;
using SakkeFutbol.Views.DetailViews;
using SakkeFutbol.Views.DetailViews.SettingsViews;
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
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listview; } }
        public List<MasterMenuItem> items;

        public MasterPage()
        {
            InitializeComponent();
            SetItems();
        }

        private void SetItems()
        {
            items = new List<MasterMenuItem>();
            items.Add(new MasterMenuItem("Info Screen1", "Sakke.png", Color.White, typeof(InfoScreen1)));
            items.Add(new MasterMenuItem("Info Screen2", "Sakke.png", Color.White, typeof(InfoScreen2)));
            items.Add(new MasterMenuItem("Settings", "Sakke.png", Color.White, typeof(SettingsScreen)));
            ListView.ItemsSource = items;
        }
    }
}