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
            FetchData();
        }
      
        private void changeEmail(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ChangeEmail());
        }
        private void changepass(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ChangeEmail());
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
            name.Text = "Name:" + Settings.Username;
            email.Text = "Email:" + Settings.Email;

            mobile.Text = "PhoneNumber " + Settings.Mobile;
            /// var client = new HttpClient();
            ///  client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);
            //  var json = await client.GetStringAsync(Constants.BaseApiAddress + "api/ideas");

            //var ideas = JsonConvert.DeserializeObject<List<Idea>>(json);
            // inventions.Text = ideas;
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