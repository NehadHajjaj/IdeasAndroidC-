using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Helper;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Faq : ContentPage
    {
        public Faq()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            label.Text = AppResource.StrF;
            label1.Text = AppResource.faq1;
            label2.Text = AppResource.faq2;
            label3.Text = AppResource.faq3;
            label4.Text = AppResource.faq4;
            label5.Text = AppResource.faq5;
            label6.Text = AppResource.faq6;
            label7.Text = AppResource.faq7;
            label8.Text = AppResource.faq8;
            label9.Text = AppResource.faq9;
            label10.Text = AppResource.faq10;
            label11.Text = AppResource.faq11;
            label12.Text = AppResource.faq12;
            label13.Text = AppResource.faq13;
            label14.Text = AppResource.faq14;
            label15.Text = AppResource.faq15;
            label16.Text = AppResource.faq16;
            label17.Text = AppResource.faq17;
            label18.Text = AppResource.faq18;
            label19.Text = AppResource.faq19;


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
    }
}