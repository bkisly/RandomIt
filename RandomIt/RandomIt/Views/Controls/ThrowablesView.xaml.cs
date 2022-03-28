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
    public partial class ThrowablesView : ContentPage
    {
        private ThrowableViewModel _viewModel;
        private string imagePrefix;
        private IEnumerable<int> _results;

        public ThrowablesView()
        {
            InitializeComponent();

            if (BindingContext is ThrowableViewModel)
            {
                _viewModel = BindingContext as ThrowableViewModel;
                _viewModel.RollResults.CollectionChanged += RollResults_CollectionChanged;

                if (BindingContext is DiceRollViewModel)
                    imagePrefix = "dice";
            }
        }

        private void RollResults_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            _results = e.NewItems as IEnumerable<int>;
        }

        private void GenerateLayout()
        {
            StackLayout rowLayout = null;

            for (int i = 0; i < _results.Count(); i++)
            {
                if (i % 3 == 0)
                {
                    rowLayout = new StackLayout { Spacing = 10 };
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