using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Todo.Views
{
  public class WifiQRPageCS : ContentPage
  {
    public WifiQRPageCS()
    {
      Title = "Connect 2 WiFi";
      Image img = new Image
      {
        Source = "wifiQR.PNG",
        HorizontalOptions = LayoutOptions.Center,
        VerticalOptions = LayoutOptions.CenterAndExpand
      };

      Content = new StackLayout
      {
        Children = {
          img
        }
      };
    }
  }
}