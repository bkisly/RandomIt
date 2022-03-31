using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        private List<Image> _images;
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

            _images = new List<Image>();
        }

        private async void ViewModel_ThrowResultsChanged(object sender, ThrowResultsChangedEventArgs e)
        {
            _results = e.ThrowResults.ToList();
            GenerateLayout();
            await AnimateLayoutAsync();
        }

        private void GenerateLayout()
        {
            StackLayout rowLayout = null;
            baseLayout.Children.Clear();
            _images.Clear();

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

                Image embeddedImage = GetEmbeddedImage(imageSource);
                rowLayout.Children.Add(embeddedImage);
                _images.Add(embeddedImage);

                if (i % 3 == 2 || i == _results.Count() - 1)
                    baseLayout.Children.Add(rowLayout);             
            }
        }

        private async Task AnimateLayoutAsync()
        {
            Image[] imagesCopy = new Image[_images.Count];
            _images.CopyTo(imagesCopy);

            foreach(Image image in imagesCopy)
            {
                await Task.WhenAny(
                    image.FadeTo(1, 200), 
                    image.ScaleTo(1, 300, Easing.CubicOut), 
                    Task.Delay(100));
            }
        }

        private static Image GetEmbeddedImage(string source)
        {
            return new Image 
            { 
                WidthRequest = 100, 
                HeightRequest = 100, 
                Source = ImageSource.FromResource(source),
                Scale = 0.5,
                Opacity = 0
            };
        }
    }
}