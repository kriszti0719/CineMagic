using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CineMagic.Views
{
    /// <summary>
    /// A TvShow's details page.
    /// </summary>
    public sealed partial class TVShowDetailsPage : Page
    {
        public TVShowDetailsPage()
        {
            this.InitializeComponent();
        }

        // <summary>
        /// Executes when the toggle button is clicked. Opens/Closes the list of episodes of a season.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments containing the clicked item.</param>
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            var grid = (Grid)button.Parent;
            var itemsControl = (ItemsControl)grid.Children[1];
            itemsControl.Visibility = itemsControl.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
