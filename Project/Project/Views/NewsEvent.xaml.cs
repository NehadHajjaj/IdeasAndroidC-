using Newtonsoft.Json;
using Project.Helper;
using Project.Model;
using Project.Services;
using System;
using System.Collections.Generic;
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
    public partial class NewsEvent : ContentPage
    {


        private readonly ApiService _apiService = new ApiService();


        public NewsEvent()
        {
            InitializeComponent();
            label.Text = AppResource.news;
            NavigationPage.SetHasNavigationBar(this, false);
            GetEventNews();

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

        public async void GetEventNews()
        {
            if (Settings.AccessToken == "")
            {
                await App.Current.MainPage.DisplayAlert("Error", "You arent Authorized", "Ok");
                _ = Navigation.PushModalAsync(new LoginPage());
            }
            else
            {
                DependencyService.Get<IProgressInterface>().Show();
                var myData = await _apiService.GetEvent();
                var myData2 = await _apiService.GetNews();
                DependencyService.Get<IProgressInterface>().Hide();


                if (myData.Count != 0 || myData2.Count != 0)
                {
                    Event eve = myData[0];
                    event1.Text = eve.Title;
                    event1.Text = AppResource.eve1;
                    Event eve2 = myData[1];
                    event2.Text = eve2.Title;
                    event2.Text = AppResource.eve2;

                    News news = myData2[0];
                    new1.Text = news.Title;
                    new1.Text = AppResource.new1;
                    News news2 = myData2[1];
                    new2.Text = news2.Title;
                    new2.Text = AppResource.new2;

                }

                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "there isnt a News and event to show", "Ok");
                    _ = Navigation.PushModalAsync(new LoginPage());
                }
            }


        }



        }
    }
