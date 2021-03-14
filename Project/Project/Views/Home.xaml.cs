using Project.Helper;
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
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            l1.Text = AppResource.h1;
            l2.Text = AppResource.h2;
            l3.Text = AppResource.h3;
            l4.Text = AppResource.h4;

        }
        public void ADD(object sender, EventArgs args)
        {

            Navigation.PushModalAsync(new AddInvetaion());

        }

        private void IdeaBank_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new IdeaBank());
        }
    }
}