using Project.Helper;
using Project.Model;
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
    public partial class WorkShops : ContentPage
    {
        private readonly ApiService _apiService = new ApiService();
        public WorkShops()
        {
            InitializeComponent();
            label.Text = AppResource.w;
            NavigationPage.SetHasNavigationBar(this, false);
            GetWorkshop();
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
        public async void GetWorkshop()
        {
            if (Settings.AccessToken == "")
            {
                await App.Current.MainPage.DisplayAlert("Error", "You arent Authorized", "Ok");
                _ = Navigation.PushModalAsync(new LoginPage());
            }
            else
            {
                DependencyService.Get<IProgressInterface>().Show();
                var myData = await _apiService.GetWorkShop();
                DependencyService.Get<IProgressInterface>().Hide();
                if (myData.Count != 0)
                {
                    WorkShop wor = myData[0];
                    WorkShop wor2 = myData[1];
                    WorkShop wor3 = myData[2];
                    WorkShop wor4 = myData[3];

                    work1.Text = wor.Title;
                    work2.Text = wor2.Title;
                    work3.Text = wor3.Title;
                    work4.Text = wor4.Title;
                    work1.Text = AppResource.w1;
                    work2.Text = AppResource.w2;
                    work3.Text = AppResource.w3;
                    work4.Text = AppResource.w4;
                    

                    pic1.Source = wor.ImagePath;
                    pic2.Source = wor2.ImagePath;
                    pic3.Source = wor3.ImagePath;
                    pic4.Source = wor4.ImagePath;

                }

                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "there isnt a WorkShops to show", "Ok");
                    _ = Navigation.PushModalAsync(new LoginPage());

                }


            }

        }
    }
}