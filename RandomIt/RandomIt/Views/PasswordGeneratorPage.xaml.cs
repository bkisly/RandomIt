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
    public partial class PasswordGeneratorPage : ContentPage
    {
        public PasswordGeneratorPage()
        {
            InitializeComponent();
        }

        private void GenerateButton_Clicked(object sender, EventArgs e)
        {
            viewModel.GeneratePassword();
        }

        private async void CopyButton_Clicked(object sender, EventArgs e)
        {
            await viewModel.CopyToClipboardAsync();
            await DisplayAlert("Copied!", "The password has been successfully copied!", "OK");
        }
    }
}