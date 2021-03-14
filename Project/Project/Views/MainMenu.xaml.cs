using Project.Helper;
using Project.Models;
using Project.Services;
using Project.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;


namespace Project.Views
{
    
    public partial class MainMenu : MasterDetailPage 
    {
        private readonly ApiService _apiService = new ApiService();
        public List<MainMenuItem> MainMenuItems { get; set; }

        public MainMenu()
        {
           
            // Set the binding context to this code behind.
            BindingContext = this;

    		// Build the Menu
    		MainMenuItems = new List<MainMenuItem>()
    		{
    			new MainMenuItem() { Title =  AppResource.m1, Icon = "user.png", TargetType = typeof(Profile) },
    			new MainMenuItem() { Title =  AppResource.m2, Icon = "course.png", TargetType = typeof(Courses) },

                    new MainMenuItem() { Title = AppResource.m3, Icon = "work.png", TargetType = typeof(WorkShops) },
                new MainMenuItem() { Title =  AppResource.m4, Icon = "event.png", TargetType = typeof(NewsEvent) },

                new MainMenuItem() { Title =  AppResource.m5, Icon = "consult.png", TargetType = typeof(Consulting) },
              new MainMenuItem() { Title =  AppResource.m6, Icon = "faq.png", TargetType = typeof(Faq) },
                new MainMenuItem() { Title =  AppResource.m7, Icon = "resource.png", TargetType = typeof(Resources) },
              new MainMenuItem() { Title =  AppResource.m8, Icon = "comtent.png", TargetType = typeof(Content) },
                 new MainMenuItem() { Title =  AppResource.m9, Icon = "logout.png", TargetType = typeof(Home) },
            };

            // Set the default page, this is the "home" page.
            Detail = new NavigationPage(new Home()) { BarBackgroundColor = Color.FromHex("C4DBC7") };

            InitializeComponent();
            setName();
        }
        public void setName()
        {
            user.Text = AppResource.m10 +" " + Settings.Username;
        }
        public async System.Threading.Tasks.Task logoutAsync()
        {
            if (Settings.AccessToken == "")
            {
                await App.Current.MainPage.DisplayAlert(AppResource.er, AppResource.e1, AppResource.ok);
                _ = Navigation.PushModalAsync(new LoginPage());
            }
            else
            {
                var IsAutho = await _apiService.Logout(Settings.AccessToken);
                if (IsAutho)
                {
                    Settings.AccessToken = "";
                    Detail = new NavigationPage(new LoginPage());
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert(AppResource.er, AppResource.nonuser, AppResource.ok);
                    await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
                }
            }
        }
        // When a MenuItem is selected.
        public void  MainMenuItem_Selected(object sender, SelectedItemChangedEventArgs e)
    	{
    		var item = e.SelectedItem as MainMenuItem;
    		if (item != null)
    		{
    			if (item.Title.Equals(AppResource.m1))
    			{
                    Detail =
                        new NavigationPage((new Profile()));
                        
                   
    			}
    			else if (item.Title.Equals(AppResource.m2))
    			{
                    Detail = new NavigationPage(new Courses());
                   
                 
    			}
                else if (item.Title.Equals(AppResource.m3))
                {
                    Detail = new NavigationPage(new WorkShops());
                  

                }
                else if (item.Title.Equals(AppResource.m4))
                {
                    Detail = new NavigationPage(new NewsEvent());
                   

                }
                else if (item.Title.Equals(AppResource.m5))
                {
                    Detail = new NavigationPage(new Consulting());
                   

                }
                else if (item.Title.Equals(AppResource.m6))
                {
                    Detail = new NavigationPage(new Faq());


                }
                else if (item.Title.Equals(AppResource.m7))
                {
                    Detail = new NavigationPage(new Resources());


                }
                else if (item.Title.Equals(AppResource.m8))
                {
                    Detail = new NavigationPage(new Content());


                }
                else if (item.Title.Equals(AppResource.m9))
                {
                    _ = logoutAsync();
                   
                    


                }
                

                MenuListView.SelectedItem = null;
    			IsPresented = false;
    		}
    	}
    }
}
