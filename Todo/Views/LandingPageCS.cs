using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Todo.Views;
using Xamarin.Forms;

namespace Todo
{
  public class LandingPageCS : ContentPage
  {
    public LandingPageCS()
    {
      Title = "Home";
      this.BackgroundColor = Color.FromHex("#161616");

      var saveButton = new Button { Text = "Saved Codes" };
      saveButton.Clicked += async (sender, e) =>
      {
        await Navigation.PushAsync(new TodoListPageCS());
      };

      ImageButton imageButton = new ImageButton
      {
        Source = "wifiKey.png",
        HorizontalOptions = LayoutOptions.Center,
        VerticalOptions = LayoutOptions.CenterAndExpand
      };
      imageButton.Clicked += OnImageButtonClicked;

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
          saveButton,
          imageButton,
          imageScanBtn,
          new Label { Text = "Home of the Herd powered by Techno Herder", TextColor = Color.LightGreen, Padding = new Thickness( 25, 0, 0, 20 ) }
        }
      };
    }
    void OnImageButtonClicked(object sender, EventArgs e)
    {
      Navigation.PushAsync(new WifiQRPage());
    }
    void OnInvImgBtnClicked(object sender, EventArgs e)
    {
      Navigation.PushAsync(new ScanPage());
    }
  }
}