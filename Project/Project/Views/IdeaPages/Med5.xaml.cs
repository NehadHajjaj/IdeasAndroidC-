﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Views.IdeaPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Med5 : ContentPage
    {
        public Med5()
        {
            InitializeComponent();
        }
        public void OnImageNameTapped(object sender, EventArgs args)
        {
            try
            {
                Navigation.PushModalAsync(new MedicalInvention());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}