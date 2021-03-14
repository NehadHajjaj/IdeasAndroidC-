using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Helper;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Content : ContentPage
    {
        public Content()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            label1.Text = AppResource.StrCont;
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
    }
}