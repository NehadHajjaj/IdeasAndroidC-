using Project.Views.IdeaPages;
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
    public partial class IdeaBank : ContentPage
    {
        public IdeaBank()
        {
            InitializeComponent();
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

        private void ShopIDSubmit1_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new EngineeringInventions());
        }

        private void ShopIDSubmit2_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new TechnoInventions());
        }

        private void ShopIDSubmit3_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MedicalInvention());
        }

      

        private void ShopIDSubmit6_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new TransportionInvention());
        }

        private void ShopIDSubmit7_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MachineLearn());
        }

        private void ShopIDSubmit8_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new InformaionSecurity());
        }

        private void ShopIDSubmit99_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CloudInventios());
        }
    }
}