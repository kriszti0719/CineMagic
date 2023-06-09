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
    public sealed partial class PersonDetailsPage : Page
    {
        public PersonDetailsPage()
        {
            this.InitializeComponent();
        }

        // <summary>
        /// Executes when the toggle button is clicked. Opens/Closes the list of movie credits.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments containing the clicked item.</param>
        private void MoviesToggleButton_Click(object sender, RoutedEventArgs e)
        {
            MoviesItemsControl.Visibility = MoviesToggleButton.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
        }

        // <summary>
        /// Executes when the toggle button is clicked. Opens/Closes the list of tv shows credits.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments containing the clicked item.</param>
        private void SeriesToggleButton_Click(object sender, RoutedEventArgs e)
        {
            SeriesItemsControl.Visibility = SeriesToggleButton.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Set the initial state of the toggle buttons and corresponding items
            MoviesItemsControl.Visibility = Visibility.Collapsed;
            MoviesToggleButton.IsChecked = false;
            SeriesItemsControl.Visibility = Visibility.Collapsed;
            SeriesToggleButton.IsChecked = false;

            base.OnNavigatedTo(e);
        }

    }
}
