using System;
using Xamarin.Forms;

namespace CodeScanner
{
    public partial class CodeListPage : ContentPage
    {
        public CodeListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetItemsAsync();
      this.BackgroundColor = Color.Black;
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CodeItemPage
            {
                BindingContext = new CodeItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new CodeItemPage
                {
                    BindingContext = e.SelectedItem as CodeItem
                });
            }
        }
    }
}
