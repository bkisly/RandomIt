using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RandomIt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RandomNumberPage : ContentPage
    {
        public RandomNumberPage()
        {
            InitializeComponent();
        }

        private void GenerateButton_Clicked(object sender, EventArgs e)
        {
            if (floatRadioButton.IsChecked)
                viewModel.GenerateRandomDouble();
            else viewModel.GenerateRandomInt();
        }
    }
}