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
    public partial class DicePage : ContentPage
    {
        public DicePage()
        {
            InitializeComponent();
            baseLayout.Children.Add(new ThrowablesView(viewModel));
        }

        private void RollButton_Clicked(object sender, EventArgs e)
        {
            viewModel.Roll();
        }
    }
}