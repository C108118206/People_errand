using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Extensions;
using people_errandd.ViewModels;
using Xamarin.Forms.Maps;

namespace people_errandd.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        public MapPage()
        {
            InitializeComponent();
            Position position = new Position(App.Latitude,App.Longitude);
            MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);
            Map map = new Map(mapSpan)
            {
                IsShowingUser = true,
                HeightRequest = 50,
                WidthRequest = 250,
                HasScrollEnabled = false,
                HasZoomEnabled = false
               
            };
            Label L=new Label
            {
                Text = "現在位置",
                FontSize = 28,
                TextColor=Color.White,
                HorizontalOptions = LayoutOptions.Center
            };
            StackLayout s = new StackLayout()
            {
                    Margin = new Thickness(50,200)
            };
            s.Children.Add(L);
            s.Children.Add(map);
            Content = s;           
        }
    }
}