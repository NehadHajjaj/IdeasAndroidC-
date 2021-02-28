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
    public partial class EngineeringInventions : ContentPage
    {
        public EngineeringInventions()
        {
            InitializeComponent();
        }

        private void ShopIDSubmit1_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Eng1());
        }

        private void ShopIDSubmit2_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Eng2());
        }

        private void ShopIDSubmit3_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Eng3());
        }

        private void ShopIDSubmit4_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Eng4());
        }

        private void ShopIDSubmit5_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Eng5());
        }

        private void ShopIDSubmit6_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Eng6());
        }

        private void ShopIDSubmit7_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Eng7());
        }

        private void ShopIDSubmit8_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Eng8());
        }

     

        private void ShopIDSubmit99_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Eng9());

        }
    }
}