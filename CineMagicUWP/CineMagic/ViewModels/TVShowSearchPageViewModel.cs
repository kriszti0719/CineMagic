using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using CineMagic.Models;
using CineMagic.Services;
using CineMagic.Views;

namespace CineMagic.ViewModels
{
    class TVShowSearchPageViewModel : ViewModelBase
    {
        public ObservableCollection<ContentList> TVShows { get; set; } =
            new ObservableCollection<ContentList>();

        /// <summary>
        /// Executes when the page is navigated to. Fetches a search result's elements' details.
        /// </summary>
        /// <param name="parameter">The navigation parameter.</param>
        /// <param name="mode">The navigation mode.</param>
        /// <param name="state">The page state.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public override async Task OnNavigatedToAsync(
            object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var service = new CineMagicService();
            var TVShowList = await service.SearchTVShowsAsync((string)parameter);
            ContentList tvListTL = new ContentList();
            tvListTL.Title = "Search Results";
            tvListTL.Id = "2";
            tvListTL.TopElement = new List<TopElementHeader>();
            foreach (var item in TVShowList.results)
            {
                if (item.name != null)
                {
                    var _tv = new TopElementHeader();
                    _tv.Id = item.id;
                    _tv.Name = item.name;
                    _tv.Type = "TVShow";
                    var images = await service.GetTVShowImageAsync(item.id);
                    if (images.posters.Count != 0)
                    {
                        string baseUrl = "https://image.tmdb.org/t/p/";
                        string file_size = "w500";
                        string file_path = images.posters[0].file_path;

                        _tv.BackgroundImage = baseUrl + file_size + file_path;

                    }
                    tvListTL.TopElement.Add(_tv);
                }
            }
            TVShows.Add(tvListTL);
        }

        /// <summary>
        /// Navigates to the details page of a chosen TV Show.
        /// </summary>
        /// <param name="id">The ID of the item.</param>
        /// <param name="type">The type of the item (Movie, TVShow, Person).</param>
        public void NavigateToDetails(int id)
        {
            NavigationService.Navigate(typeof(TVShowDetailsPage), id);
        }

        /// <summary>
        /// Navigates to the search page for the specified keyword(s) and type.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <param name="type">The type of items to search for (Movie, TVShow, Person).</param>
        public void NavigateToSearch(string query, string type)
        {
            switch (type)
            {
                case "Movie": NavigationService.Navigate(typeof(MovieSearchPage), query); break;
                case "TVShow": NavigationService.Navigate(typeof(TVShowSearchPage), query); ; break;
                case "Person": NavigationService.Navigate(typeof(PersonSearchPage), query); ; break;
                default: break;
            }
        }
    }
}
