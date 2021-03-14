using Newtonsoft.Json;
using Project.Helper;
using Project.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        private readonly Idea idea = new Idea();
        public Profile()
        {

           
        InitializeComponent();
           
            NavigationPage.SetHasNavigationBar(this, false);
            label1.Text = AppResource.pro1;
            label2.Text = AppResource.pro2;
            label3.Text = AppResource.pro3;
            label4.Text = AppResource.pro4;
            label5.Text = AppResource.pro5;
            FetchData();
        }
      
        private void changeEmail(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ChangeEmail());
        }
        private void changepass(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ChangePassword());
        }
        private void mydiss(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MyDiss());
        }
        private void myidea(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MyIdea());
        }
        void FetchData()
        {
            name.Text = AppResource.name +" "+ Settings.Username;
            email.Text = AppResource.email + " " +Settings.Email;

            mobile.Text = AppResource.mobile +" " +Settings.Mobile;
           
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