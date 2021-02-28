using Newtonsoft.Json;
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
        public NewsEvent()
        {
            InitializeComponent();
           // GetNews();
           // GetEvent();
        }
        public async void GetNews()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
           "Bearer", Settings.AccessToken);
            var response = await httpClient.GetStringAsync(Constants.BaseApiAddress + "api/Events");
            var events = JsonConvert.DeserializeObject(response);

            // event1.Text = events.Title
        }

        public async void GetEvent()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
           "Bearer", Settings.AccessToken);
            var response = await httpClient.GetStringAsync(Constants.BaseApiAddress + "api/News");
            var news = JsonConvert.DeserializeObject(response);

            //  new1.Text = news.Title
        }

    }
}