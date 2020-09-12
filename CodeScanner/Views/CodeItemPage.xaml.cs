using System;
using CodeScanner.Views;
using Xamarin.Forms;

namespace CodeScanner
{
  public partial class CodeItemPage : ContentPage
  {
    public CodeItemPage()
    {
      InitializeComponent();
    }

    async void OnSaveClicked(object sender, EventArgs e)
    {
      var codeItem = (CodeItem)BindingContext;
      await App.Database.SaveItemAsync(codeItem);
      await Navigation.PopAsync();
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
      var codeItem = (CodeItem)BindingContext;
      await App.Database.DeleteItemAsync(codeItem);
      await Navigation.PopAsync();
    }

    async void OnCancelClicked(object sender, EventArgs e)
    {
      await Navigation.PopAsync();
    }

    async void OnPreviewClicked(object sender, EventArgs e)
    {
      await Navigation.PushAsync(new GenerateCode {
                        BindingContext = (CodeItem)BindingContext
      });
    }
  }
}
