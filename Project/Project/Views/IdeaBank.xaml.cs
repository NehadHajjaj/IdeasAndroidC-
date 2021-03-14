using Project.Helper;
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
            label.Text = AppResource.idea;
            label1.Text = AppResource.idea1;
            label2.Text = AppResource.idea2;
            label3.Text = AppResource.idea3;
            label4.Text = AppResource.idea4;
            label5.Text = AppResource.idea5;
            label6.Text = AppResource.idea6;
            label7.Text = AppResource.idea7;
            label8.Text = AppResource.idea8;
            label9.Text = AppResource.idea9;
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

        private void ShopIDSubmit4_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new HousewareInventions());
        }

        private void ShopIDSubmit5_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new EnvironmentalInventions());
        }
    }
}