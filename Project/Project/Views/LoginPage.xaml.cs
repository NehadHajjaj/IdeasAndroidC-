using Project.Helper;
using Project.Models;
using Project.Services;
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
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            

            InitializeComponent();
            this.BindingContext = new LoginViewModel();
            label4.Text = AppResource.String4;
            label5.Text = AppResource.String5;
            label6.Text = AppResource.String6;
            label7.Text = AppResource.String7;
            label8.Text = AppResource.String8;
            label9.Text = AppResource.String9;
            label10.Text = AppResource.String10;
           // label11.Text = AppResource.String11;
            //label12.Text = AppResource.String12;
        }


      
        public async void Guest(object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new MainMenu());
        }
        public async void Signup(object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new SignUp());
        }

    }
}