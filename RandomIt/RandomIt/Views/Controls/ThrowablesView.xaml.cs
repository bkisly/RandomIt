using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RandomIt.ViewModels;

namespace RandomIt.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThrowablesView : StackLayout
    {
        private readonly ThrowableViewModel _viewModel;
        private readonly string _imagePrefix;

        private IList<int> _results;

        public ThrowablesView(ThrowableViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
            _viewModel.ThrowResultsChanged += ViewModel_ThrowResultsChanged;

            if (viewModel is DiceRollViewModel)
                _imagePrefix = "Dice";
            else if (viewModel is CoinFlipViewModel)
                _imagePrefix = "Coin";
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
                string imageSource = $"RandomIt.Images.{_imagePrefix}.{_imagePrefix.ToLower()}{_results[i]}.png";

                if (i % 3 == 0)
                {
                    rowLayout = new StackLayout 
                    { 
                        Spacing = 10, 
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.Center,
                    };
                }

                rowLayout.Children.Add(GetEmbeddedImage(imageSource));

                if (i % 3 == 2 || i == _results.Count() - 1)
                    baseLayout.Children.Add(rowLayout);             
            }
        }

        private static Image GetEmbeddedImage(string source)
        {
            return new Image 
            { 
                WidthRequest = 100, 
                HeightRequest = 100, 
                Source = ImageSource.FromResource(source)
            };
        }
    }
}