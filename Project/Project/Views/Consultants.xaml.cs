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
    public partial class Consultants : ContentPage
    {
        public Consultants()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            label.Text = AppResource.adviser;
            label1.Text = AppResource.ad1;
            label2.Text = AppResource.ad2;
            label3.Text = AppResource.ad3;
            label4.Text = AppResource.ad4;
            label5.Text = AppResource.ad5;
            label6.Text = AppResource.ad6;
            label7.Text = AppResource.ad7;
            label8.Text = AppResource.ad8;
          
        }
        public void OnImageNameTapped(object sender, EventArgs args)
        {
            try
            {
                Navigation.PushModalAsync(new Consulting());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ShopIDSubmit1_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ConsDiss());
        }

        private void ShopIDSubmit2_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ConsDiss());
        }

        private void ShopIDSubmit3_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ConsDiss());
        }

        private void ShopIDSubmit4_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ConsDiss());
        }

        private void ShopIDSubmit5_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ConsDiss());
        }

        private void ShopIDSubmit6_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ConsDiss());
        }

        private void ShopIDSubmit7_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ConsDiss());
        }

        private void ShopIDSubmit8_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ConsDiss());
        }
    }
}