using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FamilyTree
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class About : ContentPage
	{
		public About ()
		{
			InitializeComponent ();

            AbPage.Title = Res.btnAbout;

            LabelAbout1.Text = Res.ab1;
            LabelAbout2.Text = Res.ab2;
		}
	}
}