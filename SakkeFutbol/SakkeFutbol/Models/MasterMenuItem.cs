using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace SakkeFutbol.Models
{
    public class MasterMenuItem
    {
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Color BackgroundColor { get; set; }
        public Type TargetType { get; set; }

        public MasterMenuItem(string Title, string IconSource, Color color, Type TargetType)
        {
            this.Title = Title;
            this.IconSource = IconSource;
            this.BackgroundColor = color;
            this.TargetType = TargetType;
        }

    }
}
