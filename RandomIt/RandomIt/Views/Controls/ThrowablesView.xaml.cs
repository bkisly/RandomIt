using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using RandomIt.ViewModels;

namespace RandomIt.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThrowablesView : StackLayout
    {
        private ThrowableViewModel _viewModel;
        private string imagePrefix;
        private IList<int> _results;

        public ThrowablesView(ThrowableViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
            _viewModel.ThrowResultsChanged += ViewModel_ThrowResultsChanged;

            if (viewModel is DiceRollViewModel)
                imagePrefix = "dice";
        }

        private void ViewModel_ThrowResultsChanged(object sender, ThrowResultsChangedEventArgs e)
        {
            _results = e.ThrowResults.ToList();
            GenerateLayout();
        }

        private void GenerateLayout()
        {
            StackLayout rowLayout = null;
            baseLayout.Children.Clear();

            for (int i = 0; i < _results.Count(); i++)
            {
                if (i % 3 == 0)
                {
                    rowLayout = new StackLayout 
                    { 
                        Spacing = 10, 
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.Center,
                    };
                }

                rowLayout.Children.Add(GetEmbeddedImage());

                if (i % 3 == 2 || i == _results.Count() - 1)
                    baseLayout.Children.Add(rowLayout);             
            }
        }

        private static BoxView GetEmbeddedImage()
        {
            return new BoxView { WidthRequest = 100, HeightRequest = 100, Color = Color.Blue };
        }
    }
}