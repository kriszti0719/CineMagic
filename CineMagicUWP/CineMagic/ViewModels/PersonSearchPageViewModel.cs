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
    class PersonSearchPageViewModel : ViewModelBase
    {
        public ObservableCollection<ContentList> People { get; set; } =
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
            var PersonList = await service.SearchPeopleAsync((string)parameter);
            ContentList peopleTL = new ContentList();
            peopleTL.Title = "Search Results";
            peopleTL.Id = "3";
            peopleTL.TopElement = new List<TopElementHeader>();
            foreach (var item in PersonList.results)
            {
                if(item.name != null)
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
            }
            People.Add(peopleTL);
            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        /// <summary>
        /// Navigates to the details page of a chosen person.
        /// </summary>
        /// <param name="id">The ID of the item.</param>
        /// <param name="type">The type of the item (Movie, TVShow, Person).</param>
        public void NavigateToDetails(int id)
        {
            NavigationService.Navigate(typeof(PersonDetailsPage), id);
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
