
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

    public partial class AddInvetaion : ContentPage
    {



        public AddInvetaion()
        {

            InitializeComponent();
            label.Text = AppResource.inv;
            label1.Text = AppResource.inv1;
            label2.Text = AppResource.inv2;
            pick3.Title = AppResource.inv3;
            label4.Text = AppResource.inv4;
            pick5.Title = AppResource.inv5;
            label6.Text = AppResource.inv6;
            pick7.Title = AppResource.inv7;
            label8.Text = AppResource.inv8;
            btn1.Text = AppResource.btns;
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
