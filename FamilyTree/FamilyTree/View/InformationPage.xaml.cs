using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FamilyTree
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InformationPage : ContentPage
    {

        IInformationPageViewModel viewModel;

        Entry snameEntry;

        Entry nameEntry;

        Entry birthEntry;

        Label Sname;

        Label Name;

        Label DateOfBirth;

        Image icon;

        TableSection childrenSection;
        TableSection parentsSection;
        TableSection grandparentsSection;
        TableSection siblingsSection;
        TableSection cousinsSection;
        TableSection parthnersSection;

        IShablonPage shPage;

        public InformationPage(IInformationPageViewModel viewModel, IShablonPage shablonPage)
        {

            InitializeComponent();

            shPage = shablonPage;

            this.viewModel = viewModel;

            // BindingContext = viewModel;

            StackLayout ImageStack = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal
            };

            icon = new Image()
            {
                HeightRequest = 100,
                WidthRequest = 100,
            };

            if (viewModel.GetPerson().Sex)
                icon.Source = "girl.png";
            else
                icon.Source = "boy.png";

            TapGestureRecognizer tapGesture3 = new TapGestureRecognizer();
            tapGesture3.Tapped += TapGesture3_Tapped;
            icon.GestureRecognizers.Add(tapGesture3);


            StackLayout NameStack = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                BindingContext = viewModel.GetPerson(),
            };


            Sname = new Label()
            {

                FontSize = 20,

            };

            snameEntry = new Entry()
            {
                Placeholder = Res.ent1,
                Text = viewModel.GetPerson().Sname,
                IsVisible = false,
            };

            snameEntry.Completed += (s, e) =>
            {
                snameEntry.IsVisible = false;
            };

            nameEntry = new Entry()
            {
                Placeholder = Res.ent2,
                Text = viewModel.GetPerson().Name,
                IsVisible = false,
            };

            nameEntry.Completed += (s, e) =>
            {
                nameEntry.IsVisible = false;
            };

            birthEntry = new Entry()
            {
                Placeholder = Res.ent3,
                Text = viewModel.GetPerson().Birth,
                IsVisible = false,
            };

            birthEntry.Completed += (s, e) =>
            {
                birthEntry.IsVisible = false;
            };

            TapGestureRecognizer tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += TapGesture_Tapped;
            Sname.GestureRecognizers.Add(tapGesture);
            snameEntry.TextChanged += SnameEntry_TextChanged;



            Sname.SetBinding(Label.TextProperty, "Sname");

            Name = new Label()
            {

                FontSize = 20,
                IsEnabled = true,

            };

            Name.SetBinding(Label.TextProperty, "Name");

            TapGestureRecognizer tapGesture1 = new TapGestureRecognizer();
            tapGesture1.Tapped += TapGesture1_Tapped;
            Name.GestureRecognizers.Add(tapGesture1);
            nameEntry.TextChanged += NameEntry_TextChanged;

            DateOfBirth = new Label()
            {

                FontSize = 20,
            };

            TapGestureRecognizer tapGesture2 = new TapGestureRecognizer();
            tapGesture2.Tapped += TapGesture2_Tapped;
            DateOfBirth.GestureRecognizers.Add(tapGesture2);
            birthEntry.TextChanged += BirthEntry_TextChanged;
            DateOfBirth.SetBinding(Label.TextProperty, "Birth");

            StackLayout ParentStack = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
            };

            TableView tableView = new TableView()
            {
               
            };

            childrenSection = new TableSection()
            {
                Title = Res.inf2,

            };

            parentsSection = new TableSection()
            {
                Title = Res.inf1,
            };

            grandparentsSection = new TableSection()
            {
                Title = Res.inf4,

            };

            siblingsSection = new TableSection()
            {
                Title = Res.inf3,
            };

            cousinsSection = new TableSection()
            {
                Title = Res.inf5,
            };

            parthnersSection = new TableSection()
            {
                Title = Res.inf6,
            };

            TableRoot tableRoot = new TableRoot()
            {

                parentsSection,

                childrenSection,

                parthnersSection,

                siblingsSection,

                grandparentsSection,

                cousinsSection,
                
                

            };
            



            InfoStack.Children.Add(ImageStack);

            ImageStack.Children.Add(icon);
            ImageStack.Children.Add(NameStack);

            NameStack.Children.Add(Sname);
            NameStack.Children.Add(snameEntry);
            NameStack.Children.Add(Name);
            NameStack.Children.Add(nameEntry);
            NameStack.Children.Add(DateOfBirth);
            NameStack.Children.Add(birthEntry);

            InfoStack.Children.Add(ParentStack);

            tableView.Root = tableRoot;
            ParentStack.Children.Add(tableView);

            updateChildrenSection();
            updateParentsSection();
            updateGrandparentsSection();
            updateSiblingsSection();
            updateCousinsSection();
            updateParthnersSection();
        }

        void updateChildrenSection()
        {
            for (int i = 0; i < viewModel.numberOfRowsChildren(); ++i)
            {
                childrenSection.Add(viewModel.tableViewChildrenCell(i));
            }
        }

        void updateParentsSection()
        {
            for (int i = 0; i < viewModel.numberOfRowsParents(); ++i)
            {
                parentsSection.Add(viewModel.tableViewParentsCell(i));
            }
        }

        void updateGrandparentsSection()
        {
            for (int i = 0; i < viewModel.numberOfRowsGrandparents(); ++i)
            {
                grandparentsSection.Add(viewModel.tableViewGrandparentsCell(i));
            }
        }

        void updateSiblingsSection()
        {
            for (int i = 0; i < viewModel.numberOfRowsSiblings(); ++i)
            {
                siblingsSection.Add(viewModel.tableViewSiblingsCell(i));
            }
        }

        void updateCousinsSection()
        {
            for (int i = 0; i < viewModel.numberOfRowsCousins(); ++i)
            {
                cousinsSection.Add(viewModel.tableViewCousinsCell(i));
            }
        }

        void updateParthnersSection()
        {
            for (int i = 0; i < viewModel.numberOfRowsParthners(); ++i)
            {
                parthnersSection.Add(viewModel.tableViewParthnersCell(i));
            }
        }

        private void TapGesture3_Tapped(object sender, EventArgs e)
        {

            theBestAnimationOfTheBestAnimations(sender as View);
        }

        private void TapGesture2_Tapped(object sender, EventArgs e)
        {
            entryVisible(birthEntry);
            if (nameEntry.IsVisible)
                entryVisible(nameEntry);
            else if (snameEntry.IsVisible)
                entryVisible(snameEntry);
        }

        private void TapGesture1_Tapped(object sender, EventArgs e)
        {
            entryVisible(nameEntry);
            if (snameEntry.IsVisible)
                entryVisible(snameEntry);
            else if (birthEntry.IsVisible)
                entryVisible(birthEntry);
        }

        private void TapGesture_Tapped(object sender, EventArgs e)
        {
            entryVisible(snameEntry);
            if (nameEntry.IsVisible)
                entryVisible(nameEntry);
            else if (birthEntry.IsVisible)
                entryVisible(birthEntry);
        }

        private void entryVisible(Entry entry)
        {
            entry.IsVisible = !entry.IsVisible;
        }


        private void NameEntry_TextChanged(object sender, TextChangedEventArgs e)
        {

            viewModel.GetPerson().Name = (sender as Entry).Text;
            Name.Text = (sender as Entry).Text;
            shPage.UpdateList();
        }

        private void SnameEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.GetPerson().Sname = (sender as Entry).Text;
            Sname.Text = (sender as Entry).Text;
            shPage.UpdateList();
        }

        private void BirthEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.GetPerson().Birth = (sender as Entry).Text;
            DateOfBirth.Text = (sender as Entry).Text;
            shPage.UpdateList();
        }

        private async void theBestAnimationOfTheBestAnimations(View view)
        {
            if (view.Rotation % 360 != 0)
                return;
            var a = view.FadeTo(0, 500);
            await view.RelRotateTo(180, 500);
            if (viewModel.GetPerson().Sex)
            {
                icon.Source = "boy.png";
                viewModel.GetPerson().Sex = false;
            }
            else
            {
                icon.Source = "girl.png";
                viewModel.GetPerson().Sex = true;
            }
            var b = view.RelRotateTo(180, 500);
            var c = view.FadeTo(1, 500);
        }
    }
}