using Project.Models;
using Project.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;


namespace Project.Views
{
  
    public partial class MainMenu : MasterDetailPage 
    {
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
              new MainMenuItem() { Title = "FAQ", Icon = "faq.png", TargetType = typeof(Home) },
                new MainMenuItem() { Title = "Resources", Icon = "resource.png", TargetType = typeof(Home) },
              new MainMenuItem() { Title = "Content", Icon = "comtent.png", TargetType = typeof(Home) },
                 new MainMenuItem() { Title = "Log Out", Icon = "logout.png", TargetType = typeof(Home) },
            };

            // Set the default page, this is the "home" page.
            Detail = new NavigationPage(new Home()) { BarBackgroundColor = Color.FromHex("C4DBC7") };

            InitializeComponent();
        }

    	// When a MenuItem is selected.
    	public void MainMenuItem_Selected(object sender, SelectedItemChangedEventArgs e)
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
                else if (item.Title.Equals("Log Out"))
                {
                    Detail = new NavigationPage(new Home());


                }

                MenuListView.SelectedItem = null;
    			IsPresented = false;
    		}
    	}
    }
}
