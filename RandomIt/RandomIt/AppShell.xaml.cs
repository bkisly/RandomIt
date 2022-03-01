using RandomIt.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace RandomIt
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Shell.SetTabBarIsVisible(this, false);
        }

        private async void About_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//AboutPage");
        }
    }
}
