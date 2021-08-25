using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using people_errandd.ViewModels;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace people_errandd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdvanceGoOut : Rg.Plugins.Popup.Pages.PopupPage
    {


        public AdvanceGoOut(string _Title)
        {
            InitializeComponent();
            PageTitle.Text = _Title;
        }
        
    }
}