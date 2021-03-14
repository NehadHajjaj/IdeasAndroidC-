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
    public partial class Gdiss : ContentPage
    {
        public Gdiss()
        {
            InitializeComponent();
            label.Text = AppResource.gen;
            label1.Text = AppResource.gen1;
            label2.Text = AppResource.gen2;
            label3.Text = AppResource.gen3;
            label4.Text = AppResource.gen4;
            label5.Text = AppResource.gen5;
            disslabel.Text = AppResource.diss;
            btn.Text = AppResource.btnsend;
        }
        public void OnImageNameTapped(object sender, EventArgs args)
        {
            try
            {
                Navigation.PushModalAsync(new Consulting());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}