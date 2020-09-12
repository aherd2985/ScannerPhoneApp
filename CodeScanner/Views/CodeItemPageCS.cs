using CodeScanner.Views;
using Xamarin.Forms;

namespace CodeScanner
{
  public class CodeItemPageCS : ContentPage
  {
    public CodeItemPageCS()
    {
      Title = "Code";
      this.BackgroundColor = Color.Black;

      Entry nameEntry = new Entry();
      nameEntry.SetBinding(Entry.TextProperty, "Name");

      Entry typeEntry = new Entry();
      typeEntry.SetBinding(Entry.TextProperty, "CodeType");

      Entry notesEntry = new Entry();
      notesEntry.SetBinding(Entry.TextProperty, "Code");

      Switch syncSwitch = new Switch();
      syncSwitch.SetBinding(Switch.IsToggledProperty, "Sync");

      Button saveButton = new Button { Text = "Save" };
      saveButton.Clicked += async (sender, e) =>
      {
        var codeItem = (CodeItem)BindingContext;
        await App.Database.SaveItemAsync(codeItem);
        await Navigation.PopAsync();
      };

      Button deleteButton = new Button { Text = "Delete" };
      deleteButton.Clicked += async (sender, e) =>
      {
        var codeItem = (CodeItem)BindingContext;
        await App.Database.DeleteItemAsync(codeItem);
        await Navigation.PopAsync();
      };

      Button cancelButton = new Button { Text = "Cancel" };
      cancelButton.Clicked += async (sender, e) =>
      {
        await Navigation.PopAsync();
      };

      Button previewButton = new Button { Text = "Preview" };
      previewButton.Clicked += async (sender, e) =>
      {
        await Navigation.PushAsync(new GenerateCode
        {
          BindingContext = (CodeItem)BindingContext
        });
      };

      Content = new StackLayout
      {
        Margin = new Thickness(20),
        VerticalOptions = LayoutOptions.StartAndExpand,
        Children =
                {
                    new Label { Text = "Name", TextColor = Color.LightGreen },
                    nameEntry,
                    new Label { Text = "Type", TextColor = Color.LightGreen },
                    typeEntry,
                    new Label { Text = "Code", TextColor = Color.LightGreen },
                    notesEntry,
                    new Label { Text = "Sync", TextColor = Color.LightGreen },
                    syncSwitch,
                    saveButton,
                    deleteButton,
                    cancelButton,
                    previewButton
        }
      };
    }
  }
}
