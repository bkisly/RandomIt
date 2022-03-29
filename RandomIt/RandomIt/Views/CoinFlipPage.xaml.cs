using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomIt.Views.Controls;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RandomIt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoinFlipPage : ContentPage
    {
        public CoinFlipPage()
        {
            InitializeComponent();
            baseLayout.Children.Add(new ThrowablesView(viewModel));
        }

        private void FlipButton_Clicked(object sender, EventArgs e)
        {
            viewModel.Throw();
        }
    }
}