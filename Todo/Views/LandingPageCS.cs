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

      var saveButton = new Button { Text = "Save" };
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

      Content = new StackLayout
      {
        Children = {
          new Label { Text = "Home of the Herd powered by Techno Herder" },
          saveButton,
          imageButton
        }
      };
    }
    void OnImageButtonClicked(object sender, EventArgs e)
    {
      Navigation.PushAsync(new WifiQRPage());
    }
  }
}