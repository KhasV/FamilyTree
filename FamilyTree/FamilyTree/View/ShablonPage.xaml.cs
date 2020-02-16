using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FamilyTree
{
    public interface IShablonPage
    {
        void UpdateList();
    }

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShablonPage : ContentPage, IShablonPage
	{

        
        IMainViewModel modelView;

        public ObservableCollection<Person> Persons { get; set; }
        public static int index = 0;

        public ShablonPage (IMainViewModel modelView)
		{
            InitializeComponent ();

            this.modelView = modelView;

            BindingContext = modelView;
            
        }


        protected async void AddPageAppearing(IAddPersonPargeViewModel addClass)
        {

            await Navigation.PushAsync(new AddPersonPage(addClass));

        }

        private async void ViewCell_Tapped(object sender, EventArgs e)
        {
            

            var action = await DisplayActionSheet(Res.choose2, Res.cancel, null, Res.act1, Res.act2, Res.act3, Res.act4);

            if (action == Res.act1)
            {
                Person person = ListView1.SelectedItem as Person;
                await Navigation.PushAsync(new InformationPage(new InformationPageViewModel(person), this));

            }
            else if(action == Res.act2)
            {
                Person parent = ListView1.SelectedItem as Person;                           
                AddPageAppearing(new AddPersonPageViewModel(parent)); 
            }
            else if(action  == Res.act3)
            {
                Person parent = ListView1.SelectedItem as Person;
                AddPageAppearing(new AddPartnerPageViewModel(parent));
            }
            else if (action == Res.act4)
            {
                modelView.DeletePerson(ListView1.SelectedItem as Person);
                UpdateList();
            }


            ListView1.SelectedItem = null;
        }


        public void UpdateList()
        {
            modelView.UpdateList();
        }

        
    }
}