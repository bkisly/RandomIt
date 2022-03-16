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
    public partial class RandomListElementPage : ContentPage
    {
        public RandomListElementPage()
        {
            InitializeComponent();
        }

        private void DeleteItem_Clicked(object sender, EventArgs e)
        {
            string element = (sender as MenuItem).CommandParameter.ToString();
            viewModel.RemoveElement(element);
        }

        private void RandomButton_Clicked(object sender, EventArgs e)
        {
            viewModel.ChooseRandom();
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            viewModel.AddElement(elementNameEntry.Text);
        }
    }
}