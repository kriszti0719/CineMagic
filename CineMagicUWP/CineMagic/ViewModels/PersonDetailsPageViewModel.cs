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
    class PersonDetailsPageViewModel : ViewModelBase
    {
        private Person _person;
        public Person Person
        {
            get { return _person; }
            set { Set(ref _person, value); }
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
            var personId = (int)parameter;
            var service = new CineMagicService();
            Person = await service.GetPersonAsync(personId);
            await base.OnNavigatedToAsync(parameter, mode, state);
        }
    }
}
