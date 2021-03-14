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
    public partial class MyIdea : ContentPage
    {
        private readonly ApiService _apiService = new ApiService();
        public MyIdea()
        {
            InitializeComponent();
            FetchDataAsync();
        }

        public void OnImageNameTapped(object sender, EventArgs args)
        {
            try
            {
                Navigation.PushModalAsync(new Profile());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async void FetchDataAsync()
        {
            if (Settings.AccessToken == "")
            {
                await App.Current.MainPage.DisplayAlert(AppResource.er, AppResource.nonuser, AppResource.ok);
                _ = Navigation.PushModalAsync(new LoginPage());
            }
            else
            {

                DependencyService.Get<IProgressInterface>().Show();
                var idea = await _apiService.GetIdeasAsync(Settings.AccessToken);

                DependencyService.Get<IProgressInterface>().Hide();
                if (idea.Count != 0)
                {
                    ListView1.ItemsSource = idea;
                }

                else
                {
                    await App.Current.MainPage.DisplayAlert(AppResource.er, AppResource.id, AppResource.ok);
                    _ = Navigation.PushModalAsync(new MainMenu());

                }
            }
        }
    }
}