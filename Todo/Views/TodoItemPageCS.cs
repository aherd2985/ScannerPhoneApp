using Xamarin.Forms;

namespace Todo
{
  public class TodoItemPageCS : ContentPage
  {
    public TodoItemPageCS()
    {
      Title = "Code";
      this.BackgroundColor = Color.Black;

      Entry nameEntry = new Entry();
      nameEntry.SetBinding(Entry.TextProperty, "Name");

      Entry typeEntry = new Entry();
      typeEntry.SetBinding(Entry.TextProperty, "Type");

      Entry notesEntry = new Entry();
      notesEntry.SetBinding(Entry.TextProperty, "Code");

      Switch syncSwitch = new Switch();
      syncSwitch.SetBinding(Switch.IsToggledProperty, "Sync");

      Button saveButton = new Button { Text = "Save" };
      saveButton.Clicked += async (sender, e) =>
      {
        var todoItem = (TodoItem)BindingContext;
        await App.Database.SaveItemAsync(todoItem);
        await Navigation.PopAsync();
      };

      Button deleteButton = new Button { Text = "Delete" };
      deleteButton.Clicked += async (sender, e) =>
      {
        var todoItem = (TodoItem)BindingContext;
        await App.Database.DeleteItemAsync(todoItem);
        await Navigation.PopAsync();
      };

      Button cancelButton = new Button { Text = "Cancel" };
      cancelButton.Clicked += async (sender, e) =>
      {
        await Navigation.PopAsync();
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
                    cancelButton
        }
      };
    }
  }
}
