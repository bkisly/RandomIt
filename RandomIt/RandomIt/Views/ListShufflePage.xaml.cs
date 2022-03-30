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
    public partial class ListShufflePage : ContentPage
    {
        public ListShufflePage()
        {
            InitializeComponent();
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            viewModel.AddElement();
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.SelectedElements = addedElements.SelectedItems;
        }

        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            viewModel.ClearElements();
        }

        private void ShuffleButton_Clicked(object sender, EventArgs e)
        {
            viewModel.Shuffle();
        }

        private void RemoveSelected_Button(object sender, EventArgs e)
        {
            viewModel.RemoveSelectedElements();
        }
    }
}