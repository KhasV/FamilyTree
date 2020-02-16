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
	public partial class Options : ContentPage
	{
        

		public Options ()
		{
			InitializeComponent ();
          

            UpdateView();

            if (Settings.settings.darkMode)
            {
                Settings.settings.darkMode = false;
                SwitchCell1.On = true;
            }
            if (Settings.settings.isRussian)
            {
                Settings.settings.isRussian = false;
                SwitchCell2.On = true;
            }
        }

        public void UpdateView()
        {
            OptPAge.Title = Res.btnOpt;
            sec1.Title = Res.opt1;
            sec2.Title = Res.opt2;
            SwitchCell1.Text = Res.op1;
            SwitchCell2.Text = Res.op2;

            
        }
        
        private void Switch1_Toggled(object sender, ToggledEventArgs e)
        {
            Settings.settings.darkMode = !Settings.settings.darkMode;
            MainPage.mdp.updateView();
        }

        private void Switch2_Toggled(object sender, ToggledEventArgs e)
        {
            Settings.settings.isRussian = !Settings.settings.isRussian;

            bool IsToggled = e.Value;
            if (IsToggled)
            {
                Res.Culture = new System.Globalization.CultureInfo("ru-RU");
                
            }
            else
            {
               Res.Culture = new System.Globalization.CultureInfo("");
            }

            UpdateView();
            MainPage.mdp.updateView();
           
        }
    }
}