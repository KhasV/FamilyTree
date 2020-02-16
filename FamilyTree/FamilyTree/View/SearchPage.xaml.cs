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
	public partial class SearchPage : ContentPage, IShablonPage
	{
        ISearchPageViewModel modelView;

		public SearchPage (ISearchPageViewModel modelView)
		{
			InitializeComponent ();

            SrchPage.Title = Res.btnSearch;
            SearchBar1.Placeholder = Res.s1;

            this.modelView = modelView;
            BindingContext = modelView;
            SearchBar1.TextChanged += SearchBar1_TextChanged; ;
		}

        private void SearchBar1_TextChanged(object sender, TextChangedEventArgs e)
        {
            modelView.Searching(SearchBar1.Text);
        }

        public void UpdateList()
        {
            modelView.UpdateList();
        }

        private void SearchBar1_SearchButtonPressed(object sender, EventArgs e)
        {
            modelView.Searching(SearchBar1.Text);
        }

        private async void ViewCell_Tapped(object sender, EventArgs e)
        {
            Person person = ListView1.SelectedItem as Person;
            await Navigation.PushAsync(new InformationPage(new InformationPageViewModel(person), this));
            ListView1.SelectedItem = null;
        }
        
    }
}