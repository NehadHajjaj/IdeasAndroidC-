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