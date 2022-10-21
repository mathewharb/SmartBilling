using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.MODEL
{
    class AppSettingModel
    {
        public int AppSettingsID { get; set; }
        public string ApplicationName { get; set; }
        public string BackgroundImage { get; set; }
        public string Logo { get; set; }
        public string FooterTitle { get; set; }
        public string FooterText { get; set; }
        public string Printer { get; set; }
        public int UnitWidth { get; set; }
        public int UnitHeight { get; set; }
        public int FontSize { get; set; }

    }
}
