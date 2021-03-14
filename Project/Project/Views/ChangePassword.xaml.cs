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
    public partial class ChangePassword : ContentPage
    {
        public ChangePassword()
        {
            InitializeComponent();
            label.Text = AppResource.change2;
            entry1.Placeholder = AppResource.pass1;
            entry2.Placeholder = AppResource.pass2;
            entry3.Placeholder = AppResource.pass3;
            btn1.Text =AppResource.btnsave;
            btn2.Text = AppResource.btnres;
        }
        public void OnImageNameTapped(object sender, EventArgs args)
        {
            try
            {
                Navigation.PushModalAsync(new Profile());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}