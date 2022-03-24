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

            // TODO: Replace the list of strings to list of ListElement objects
            // in order to unify every element
        }

        private void RandomButton_Clicked(object sender, EventArgs e)
        {
            viewModel.ChooseRandom();
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            viewModel.AddElement();
        }

        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            viewModel.ClearElements();
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            viewModel.RemoveSelectedElements();
        }

        private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.SelectedElements = collectionView.SelectedItems;
        }
    }
}