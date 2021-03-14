using Project.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Resources : ContentPage
    {
        public Resources()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            label.Text = AppResource.res;
            label1.Text = AppResource.res1;
            label2.Text = AppResource.res2;
           
        }
        public void OnImageNameTapped(object sender, EventArgs args)
        {
            try
            {
                Navigation.PushModalAsync(new MainMenu());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }  }