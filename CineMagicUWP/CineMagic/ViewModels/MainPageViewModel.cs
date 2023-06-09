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
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<ContentList> TopLists { get; set; } =
            new ObservableCollection<ContentList>();

        /// <summary>
        /// Executes when the page is navigated to.
        /// Fetches all 3 type of TopLists.
        /// </summary>
        /// <param name="parameter">The navigation parameter.</param>
        /// <param name="mode">The navigation mode.</param>
        /// <param name="state">The page state.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public override async Task OnNavigatedToAsync(
            object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var service = new CineMagicService();

            var MovieList = await service.GetPopularMoviesAsync();
            ContentList moviesTL = new ContentList();
            moviesTL.Title = "Trending Movies";
            moviesTL.Id = "1";
            moviesTL.TopElement = new List<TopElementHeader>();
            foreach (var item in MovieList.results)
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
            TopLists.Add(moviesTL);
       

            var TVShowList = await service.GetPopularTVShowsAsync();
            ContentList tvListTL = new ContentList();
            tvListTL.Title = "Trending TV Shows";
            tvListTL.Id = "2";
            tvListTL.TopElement = new List<TopElementHeader>();
            foreach (var item in TVShowList.results)
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
            TopLists.Add(tvListTL);

            var PersonList = await service.GetPopularPeopleAsync();
            ContentList peopleTL = new ContentList();
            peopleTL.Title = "Popular People";
            peopleTL.Id = "3";
            peopleTL.TopElement = new List<TopElementHeader>();
            foreach (var item in PersonList.results)
            {
                var _person = new TopElementHeader();
                _person.Id = item.id;
                _person.Name = item.name;
                _person.Type = "Person";
                var images = await service.GetPersonImageAsync(item.id);
                if (images.profiles.Count != 0)
                {
                    string baseUrl = "https://image.tmdb.org/t/p/";
                    string file_size = "w500";
                    string file_path = images.profiles[0].file_path;

                    _person.BackgroundImage = baseUrl + file_size + file_path;

                }
                peopleTL.TopElement.Add(_person);
            }            
            TopLists.Add(peopleTL);
            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        /// <summary>
        /// Navigates to the details page for the specified type.
        /// </summary>
        /// <param name="id">The ID of the item.</param>
        /// <param name="type">The type of the item (Movie, TVShow, Person).</param>
        public void NavigateToDetails(int id, string type)
        {
            switch (type)
            {
                case "Movie": NavigationService.Navigate(typeof(MovieDetailsPage), id); break;
                case "TVShow": NavigationService.Navigate(typeof(TVShowDetailsPage), id); ; break;
                case "Person": NavigationService.Navigate(typeof(PersonDetailsPage), id); ; break;
                default: break;
            }            
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
                case "TVShow": NavigationService.Navigate(typeof(TVShowSearchPage), query); break;
                case "Person": NavigationService.Navigate(typeof(PersonSearchPage), query); break;
                default: break;
            }
        }
    }
}
