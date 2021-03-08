using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Views.IdeaPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MedicalInvention : ContentPage
    {
        public MedicalInvention()
        {
            InitializeComponent();
        }
        public void OnImageNameTapped(object sender, EventArgs args)
        {
            try
            {
                Navigation.PushModalAsync(new IdeaBank());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void ShopIDSubmit1_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Med1());
        }

        private void ShopIDSubmit2_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Mde2());
        }

        private void ShopIDSubmit3_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Med3());
        }

        private void ShopIDSubmit4_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Med4());
        }

        private void ShopIDSubmit5_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Med5());
        }

        private void ShopIDSubmit6_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Med6());
        }

        private void ShopIDSubmit7_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Med7());
        }

        private void ShopIDSubmit8_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Med8());
        }



       
    }
}