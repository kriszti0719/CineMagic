using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using System.Xml.Linq;
using Windows.UI.Xaml.Navigation;
using Template10.Mvvm;
using CineMagic.Models;
using CineMagic.Services;

namespace CineMagic.ViewModels
{
    class MovieDetailsPageViewModel : ViewModelBase
    {
        private Movie _movie;
        public Movie Movie
        {
            get { return _movie;  }
            set { Set(ref _movie, value);  }
        }

        /// <summary>
        /// Executes when the page is navigated to. Fetches all of its details and stores it.
        /// </summary>
        /// <param name="parameter">The navigation parameter.</param>
        /// <param name="mode">The navigation mode.</param>
        /// <param name="state">The page state.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public override async Task OnNavigatedToAsync(
            object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var movieId = (int)parameter;
            var service = new CineMagicService();
            Movie = await service.GetMovieAsync(movieId);
            
            await base.OnNavigatedToAsync(parameter, mode, state);
        }
    }
}
