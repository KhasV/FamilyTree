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
	public partial class AddPersonPage : ContentPage
	{
        IAddPersonPargeViewModel viewModel;

		public AddPersonPage(IAddPersonPargeViewModel viewModel)
		{
			InitializeComponent ();
            this.viewModel = viewModel;

            AddPage.Title = Res.add1;
            NameEntry.Placeholder = Res.add2;
            SNameEntry.Placeholder = Res.add3;
            DateOfBirthEntry.Placeholder = Res.add4;
            lMale.Text = Res.add5;
            lFemale.Text = Res.add6;
            CreateButton.Text = Res.add7;
            
        }

        private async void CreateButton_Clicked(object sender, EventArgs e)
        {
            if(NameEntry.Text == null || SNameEntry.Text == null || DateOfBirthEntry.Text == null)
            { 
                await DisplayAlert(Res.w1, Res.w2, "OK");
                return;
            }

            viewModel.createNewPerson(NameEntry.Text, SNameEntry.Text, DateOfBirthEntry.Text, SexSwitch.IsToggled);
            

            await Navigation.PopAsync();
        }
    }
}