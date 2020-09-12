using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CodeScanner
{
    public partial class App : Application
    {
        static CodeItemDatabase database;

        public App()
        {
            InitializeComponent();

      var nav = new NavigationPage(new LandingPageCS())
      {
        BarBackgroundColor = (Color)App.Current.Resources["primaryColor"],
        BarTextColor = Color.White
      };

      MainPage = nav;
        }

        public static CodeItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new CodeItemDatabase();
                }
                return database;
            }
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }
    }
}

