using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FamilyTree
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Settings.settings = new Settings(false, false);

            //Settings.Save();

            Settings.Load();


            if (Settings.settings.isRussian)
            {
                Res.Culture = new System.Globalization.CultureInfo("ru-RU");
            }

            MainPage = new NavigationPage(new SplashPage())
            {
                BarBackgroundColor = Color.FromHex("#2b8200")
            };

        }

        protected override void OnStart()
        {
            // Handle when your app starts

        }

        protected override void OnSleep()
        {
            Settings.Save();
            JsonPersonArchive.Save();
            JsonTree.Save();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

       

    }
}
