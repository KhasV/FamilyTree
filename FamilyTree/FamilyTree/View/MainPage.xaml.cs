using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FamilyTree
{

    public partial class MainPage : MasterDetailPage
    {
        public static MainPage mdp;

        public MainPage()
        {
            InitializeComponent();

            Detail = new NavigationPage(new FirstPage())
            {
                BarBackgroundColor = Settings.GetBarBackgroundColor()
            };

            updateView();

            IsPresented = true;

            mdp = this;

        }

        public void updateView()
        {
            Choose.Text = Res.choose1;
            btnMain.Text = Res.btnMain;
            btnOpt.Text = Res.btnOpt;
            btnAbout.Text = Res.btnAbout;
            Search.Text = Res.btnSearch;
            //MesBtn.Text = Res.btnTouch;

            StackLayout1.BackgroundColor = Settings.GetMainPageColor();
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Options())
            {
                BarBackgroundColor = Settings.GetBarBackgroundColor()
            };

            IsPresented = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new About())
            {
                BarBackgroundColor = Settings.GetBarBackgroundColor()
            };

            IsPresented = false;
        }
        private void Button3_Click(object sender, EventArgs e)
        {

            Detail = new NavigationPage(new FirstPage())
            {
                BarBackgroundColor = Settings.GetBarBackgroundColor()
            };

            IsPresented = false;
        }

        private async void Button4_Click(object sender, EventArgs e)
        {
            bool result = await DisplayAlert(Res.t1, Res.t2, Res.t3, Res.t4);
            if (result)
            {
                
            }
            else
            {

            }


        }

        private void Search_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new SearchPage(new SearchPageViewModel()))
            {
                BarBackgroundColor = Settings.GetBarBackgroundColor()
            };

            IsPresented = false;
        }
    }
}
