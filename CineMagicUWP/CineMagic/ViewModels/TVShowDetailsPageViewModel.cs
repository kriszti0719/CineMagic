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
    class TVShowDetailsPageViewModel : ViewModelBase
    {
        private TVShow _tvshow;
        public TVShow TVShow
        {
            get { return _tvshow; }
            set { Set(ref _tvshow, value); }
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
            var tvshowId = (int)parameter;
            var service = new CineMagicService();
            TVShow = await service.GetTVShowAsync(tvshowId);
            await base.OnNavigatedToAsync(parameter, mode, state);

        }
    }
}
