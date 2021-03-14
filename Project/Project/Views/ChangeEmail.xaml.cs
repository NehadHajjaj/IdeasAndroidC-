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
    public partial class ChangeEmail : ContentPage
    {
        public ChangeEmail()
        {
            InitializeComponent();
            label.Text = AppResource.change1;
            entry1.Placeholder = AppResource.em1;
            entry2.Placeholder = AppResource.em2;
            entry3.Placeholder = AppResource.em3;
            btn1.Text = AppResource.btnsave;
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