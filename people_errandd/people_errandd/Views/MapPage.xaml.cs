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
                HasScrollEnabled = true,
                HasZoomEnabled = true              
            };
            
            WebView View = new WebView
            {
                Source= "https://uri.amap.com/marker?position="+App.Longitude+","+App.Latitude+"&callnative=1"
                ,
                VerticalOptions = LayoutOptions.FillAndExpand
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
            if(map.IsEnabled)
            {
                s.Children.Add(map);
         }
            else
            {
                s.Margin = new Thickness(20, 100);
                s.Children.Add(View);
                
            }
            //s.Children.Add(map);
            Content = s;           
        }
    }
}