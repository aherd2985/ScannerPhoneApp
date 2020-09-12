using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ZXing;

namespace CodeScanner.Views
{
  public partial class ScanPage : ContentPage
  {
    public ScanPage()
    {
      InitializeComponent();
    }
    public void scanView_OnScanResult(Result result)
    {
      Device.BeginInvokeOnMainThread(async () =>
      {
        CodeItem newItem = new CodeItem();
        newItem.Name = result.BarcodeFormat.ToString();
        newItem.Code = result.Text;
        newItem.CodeType = result.BarcodeFormat.ToString();
        await App.Database.SaveItemAsync(newItem);
        await DisplayAlert("Scanned result", "The barcode's text is " + result.Text + ". The barcode's format is " + result.BarcodeFormat, "OK");
      });
    }
  }
}
