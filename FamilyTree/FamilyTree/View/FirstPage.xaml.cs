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
	public partial class FirstPage : CarouselPage 
    {

        public static CarouselPage carousel;

        public FirstPage ()
		{

			InitializeComponent ();
      
            for(int i = 0; i <  PersonArchive.peopleList.Count  ; ++i)
            {
                CarouselPage1.Children.Add (new ShablonPage(new MainViewModel(i)));             
            }
            CarouselPage1.Children[0].IsEnabled = false;
            CarouselPage1.CurrentPage = CarouselPage1.Children[CarouselPage1.Children.Count - 1];

            carousel = this;

        }
    }
}