using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;


using Xamarin.Forms;
using System.Threading.Tasks;
namespace FamilyTree
{
    class SplashPage : ContentPage
    {
        Image splashImage;

        public SplashPage()
        {
            /*
            PersonArchive.peopleList = new List<ObservableCollection<Person>>();
            PersonArchive.peopleList.Add(new ObservableCollection<Person>());
            PersonArchive.peopleList.Add(new ObservableCollection<Person>());
            PersonArchive.peopleList.Add(new ObservableCollection<Person>());
            PersonArchive.peopleList.Add(new ObservableCollection<Person>());

            PersonArchive.peopleList[0].Add(new Person("Our", "Creator", false, "00.00.0000", 0));
            PersonArchive.peopleList[1].Add(new Person("Person", "First", false, "00.00.0001", 1));
            PersonArchive.peopleList[1].Add(new Person("Personas", "First", false, "00.00.0001", 1));
            PersonArchive.peopleList[2].Add(new Person("Per", "Second", true, "00.00.0002", 2));
            PersonArchive.peopleList[2].Add(new Person("Pers", "Second", false, "00.00.0003", 2));
            PersonArchive.peopleList[3].Add(new Person("Perso", "Third", true, "00.00.0004", 3));

            Guid root = Tree.initTree();

            Tree.AddChild(root, PersonArchive.peopleList[0][0].id);
            Tree.AddChild(PersonArchive.peopleList[0][0].id, PersonArchive.peopleList[1][0].id);
            Tree.AddChild(PersonArchive.peopleList[0][0].id, PersonArchive.peopleList[1][1].id);
            Tree.AddChild(PersonArchive.peopleList[1][0].id, PersonArchive.peopleList[2][0].id);
            Tree.AddChild(PersonArchive.peopleList[1][0].id, PersonArchive.peopleList[2][1].id);
            Tree.AddChild(PersonArchive.peopleList[2][1].id, PersonArchive.peopleList[3][0].id);

            JsonPersonArchive.Save();
                        JsonTree.Save();
            */

            JsonPersonArchive.Load();
            JsonTree.Load();

            NavigationPage.SetHasNavigationBar(this, false);
            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "tree3.png",
                WidthRequest = 300,
                HeightRequest = 300
            };
            AbsoluteLayout.SetLayoutFlags(splashImage,
                AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage,
                new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);
            this.BackgroundColor = Color.FromHex("FFFFFF");
            this.Content = sub;
        }

        protected override async void OnAppearing()
        {


            base.OnAppearing();


            await splashImage.ScaleTo(1, 1700);

            await splashImage.ScaleTo(0.9, 1200, Easing.Linear);
                  //splashImage.RotateTo(360, 1200, Easing.Linear);
            await splashImage.ScaleTo(200, 1200, Easing.Linear);
            MainPage pg1 = new MainPage();
            NavigationPage.SetHasBackButton(pg1, false);
            NavigationPage.SetHasNavigationBar(pg1, false);
            await Navigation.PushAsync(pg1);
            // Application.Current.MainPage = new NavigationPage(pg1);
            //await Navigation.PopAsync();

        }


    }
}
