using CineMagic.Models;
using System;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CineMagic.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Executes when an item is clicked. Navigates to the details page of the clicked item.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments containing the clicked item.</param>
        private void OnItemClick(object sender, ItemClickEventArgs e)
        {
            var item = (TopElementHeader)e.ClickedItem;
            ViewModel.NavigateToDetails(item.Id, item.Type);
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
