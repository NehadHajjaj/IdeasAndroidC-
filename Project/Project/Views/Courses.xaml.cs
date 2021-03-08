﻿using Project.Helper;
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
    public partial class Courses : ContentPage
    {
        private readonly ApiService _apiService = new ApiService();
        public Courses()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            GetCourse();

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
        public async void GetCourse()
        {
            if (Settings.AccessToken == "")
            {
                await App.Current.MainPage.DisplayAlert("Error", "You arent Authorized", "Ok");
                _ = Navigation.PushModalAsync(new LoginPage());
            }
            else
            {
                DependencyService.Get<IProgressInterface>().Show();


                var myData = await _apiService.GetCourse();
                DependencyService.Get<IProgressInterface>().Hide();


                if (myData.Count != 0)
                {
                    Course cour = myData[0];
                    Course cour2 = myData[1];
                    Course cour3 = myData[2];
                    Course cour4 = myData[3];

                    course1.Text = cour.Title;
                    course2.Text = cour2.Title;
                    course3.Text = cour3.Title;
                    course4.Text = cour4.Title;

                    pic1.Source = cour.ImagePath;
                    pic2.Source = cour2.ImagePath;
                    pic3.Source = cour3.ImagePath;
                    pic4.Source = cour4.ImagePath;

                }

                else
                {

                    await App.Current.MainPage.DisplayAlert("Error", "there isnt a course to show", "Ok");
                    _ = Navigation.PushModalAsync(new LoginPage());

                }




            }

        }
    }
}