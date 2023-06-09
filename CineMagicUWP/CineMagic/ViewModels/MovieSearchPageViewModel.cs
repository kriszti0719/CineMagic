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
    class MovieSearchPageViewModel : ViewModelBase
    {
        public ObservableCollection<ContentList> Movies { get; set; } =
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
            var MovieList = await service.SearchMoviesAsync((string)parameter);
            ContentList moviesTL = new ContentList();
            moviesTL.Title = "Search Results";
            moviesTL.Id = "1";
            moviesTL.TopElement = new List<TopElementHeader>();
            foreach (var item in MovieList.results)
            {
                if(item.title != null)
                {
                    var _movie = new TopElementHeader();
                    _movie.Id = item.id;
                    _movie.Name = item.title;
                    _movie.Type = "Movie";
                    var images = await service.GetMovieImageAsync(item.id);
                    if (images.posters.Count != 0)
                    {
                        string baseUrl = "https://image.tmdb.org/t/p/";
                        string file_size = "w500";
                        string file_path = images.posters[0].file_path;

                        _movie.BackgroundImage = baseUrl + file_size + file_path;

                    }
                    moviesTL.TopElement.Add(_movie);
                }
            }
            Movies.Add(moviesTL);
            
            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        /// <summary>
        /// Navigates to the details page of a chosen movie.
        /// </summary>
        /// <param name="id">The ID of the item.</param>
        /// <param name="type">The type of the item (Movie, TVShow, Person).</param>
        public void NavigateToDetails(int id)
        {
           NavigationService.Navigate(typeof(MovieDetailsPage), id);
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
