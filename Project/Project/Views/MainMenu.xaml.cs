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
    			new MainMenuItem() { Title = "User Profile", Icon = "user.png", TargetType = typeof(Profile) },
    			new MainMenuItem() { Title = "Courses", Icon = "course.png", TargetType = typeof(Courses) },

                    new MainMenuItem() { Title = "Workshops", Icon = "work.png", TargetType = typeof(WorkShops) },
                new MainMenuItem() { Title = "New&Event", Icon = "event.png", TargetType = typeof(NewsEvent) },

                new MainMenuItem() { Title = "Consulting", Icon = "consult.png", TargetType = typeof(Consulting) },
              new MainMenuItem() { Title = "FAQ", Icon = "faq.png", TargetType = typeof(Faq) },
                new MainMenuItem() { Title = "Resources", Icon = "resource.png", TargetType = typeof(Resources) },
              new MainMenuItem() { Title = "Content", Icon = "comtent.png", TargetType = typeof(Content) },
                 new MainMenuItem() { Title = "Log Out", Icon = "logout.png", TargetType = typeof(Home) },
            };

            // Set the default page, this is the "home" page.
            Detail = new NavigationPage(new Home()) { BarBackgroundColor = Color.FromHex("C4DBC7") };

            InitializeComponent();
            setName();
        }
        public void setName()
        {
            user.Text = "Welcome  "+Settings.Username;
        }
        public async System.Threading.Tasks.Task logoutAsync()
        {
          
            var IsAutho = await _apiService.Logout(Settings.AccessToken);
            if (IsAutho)
            {
                Settings.AccessToken = "";
                Detail = new NavigationPage(new LoginPage());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "You Arent Authorized, Pleas Login", "Ok");
                await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
            }
        }
        // When a MenuItem is selected.
        public void  MainMenuItem_Selected(object sender, SelectedItemChangedEventArgs e)
    	{
    		var item = e.SelectedItem as MainMenuItem;
    		if (item != null)
    		{
    			if (item.Title.Equals("User Profile"))
    			{
                    Detail =
                        new NavigationPage((new Profile()));
                        
                   
    			}
    			else if (item.Title.Equals("Courses"))
    			{
                    Detail = new NavigationPage(new Courses());
                   
                 
    			}
                else if (item.Title.Equals("Workshops"))
                {
                    Detail = new NavigationPage(new WorkShops());
                  

                }
                else if (item.Title.Equals("New&Event"))
                {
                    Detail = new NavigationPage(new NewsEvent());
                   

                }
                else if (item.Title.Equals("Consulting"))
                {
                    Detail = new NavigationPage(new Consulting());
                   

                }
                else if (item.Title.Equals("FAQ"))
                {
                    Detail = new NavigationPage(new Faq());


                }
                else if (item.Title.Equals("Resources"))
                {
                    Detail = new NavigationPage(new Resources());


                }
                else if (item.Title.Equals("Content"))
                {
                    Detail = new NavigationPage(new Content());


                }
                else if (item.Title.Equals("Log Out"))
                {
                    logoutAsync();
                   
                    


                }
                

                MenuListView.SelectedItem = null;
    			IsPresented = false;
    		}
    	}
    }
}
