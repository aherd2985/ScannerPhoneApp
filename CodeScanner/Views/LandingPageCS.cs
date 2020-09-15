using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeScanner.Views;
using Xamarin.Forms;

namespace CodeScanner
{
  public class LandingPageCS : ContentPage
  {
    public LandingPageCS()
    {
      Title = "Home";
      this.BackgroundColor = Color.FromHex("#161616");

      ImageButton codeButton = new ImageButton
      {
        Source = "code.png",
        HorizontalOptions = LayoutOptions.Center,
        VerticalOptions = LayoutOptions.CenterAndExpand
      };
      codeButton.Clicked += OnCodeImageButtonClicked;

      ImageButton imageScanBtn = new ImageButton
      {
        Source = "ScanBtn.png",
        HorizontalOptions = LayoutOptions.Center,
        VerticalOptions = LayoutOptions.CenterAndExpand,
        BackgroundColor = Color.LightBlue
      };
      imageScanBtn.Clicked += OnInvImgBtnClicked;

      Content = new StackLayout
      {
        Children = {
          codeButton,
          imageScanBtn,
          new Label { Text = "Techno Herder", TextColor = Color.LightGreen, Padding = new Thickness( 25, 0, 0, 20 ) }
        }
      };
    }
    void OnInvImgBtnClicked(object sender, EventArgs e)
    {
      Navigation.PushAsync(new ScanPage());
    }
    void OnCodeImageButtonClicked(object sender, EventArgs e)
    {
      Navigation.PushAsync(new CodeListPageCS());
    }
  }
}