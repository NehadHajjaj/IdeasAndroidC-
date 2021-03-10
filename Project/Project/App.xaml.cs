using Project.Views;
using Project.Views.IdeaPages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Project
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new IdeaBank();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
