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
    public partial class Form : ContentPage
    {
        public Form()
        {
           
            InitializeComponent();
          
            label17.Text = AppResource.String17;
            label18.Text = AppResource.String18;
            label19.Text = AppResource.String19;
            label20.Text = AppResource.String20;
            label21.Text = AppResource.String21;
            label22.Text = AppResource.String22;
            label23.Text = AppResource.String23;
            label24.Text = AppResource.String24;
            label25.Text = AppResource.String25;
            label26.Text = AppResource.String26;
            label27.Text = AppResource.String27;
            label28.Text = AppResource.String28;
            label29.Text = AppResource.String29;
            label30.Content = AppResource.String30;
            label31.Content = AppResource.String31;
           
        }
    }
}