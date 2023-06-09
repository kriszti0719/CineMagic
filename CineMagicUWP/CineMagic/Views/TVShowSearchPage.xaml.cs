using CineMagic.Models;
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
    /// Shows a TvShow's search results.
    /// </summary>
    public sealed partial class TVShowSearchPage : Page
    {
        public TVShowSearchPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Executes when an item is clicked. Navigates to the details page of the clicked item.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments containing the clicked item.</param>
        private void OnItemClick(object sender, ItemClickEventArgs e)
        {
            var item = (TopElementHeader)e.ClickedItem;
            ViewModel.NavigateToDetails(item.Id);
        }

        /// <summary>
        /// Executes when the search button is clicked. Navigates to the search page with the specified search query and category.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void OnSearchClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var searchText = SearchTextBox.Text;
            switch (CategoryComboBox.SelectedIndex)
            {
                case 0: ViewModel.NavigateToSearch(searchText, "Movie"); break;
                case 1: ViewModel.NavigateToSearch(searchText, "TVShow"); break;
                case 2: ViewModel.NavigateToSearch(searchText, "Person"); break;
            }
        }
    }
}
