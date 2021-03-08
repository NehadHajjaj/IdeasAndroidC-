using Project.Helper;
using Project.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Project
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            label1.Text = AppResource.String1;
            label2.Text = AppResource.String2;
            label3.Text = AppResource.String3;
          
        }
      public  void OnImageNameTapped(object sender, EventArgs args)
        {
            try
            {
                Navigation.PushModalAsync(new LoginPage());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
