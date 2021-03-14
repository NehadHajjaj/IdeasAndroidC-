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
    public partial class Consulting : ContentPage
    {
        public Consulting()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            label.Text = AppResource.cons;
            label1.Text = AppResource.con1;
            label2.Text = AppResource.con2;
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

        private void ShopIDSubmit1_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Gdiss());
        }

        private void ShopIDSubmit2_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Consultants());
        }
       
    }
}