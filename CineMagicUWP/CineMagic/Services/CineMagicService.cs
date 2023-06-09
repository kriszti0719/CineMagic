using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using CineMagic.Models;


namespace CineMagic.Services
{
    class CineMagicService
    {
        private readonly Uri serverUrl = new Uri("https://api.themoviedb.org/3/");
        private readonly string key = "c373a6e00767747afeed7b413b3ef27a";

        /// <summary>
        /// Sends an HTTP GET request to the specified URI and deserializes the response JSON into an object of type T.
        /// </summary>
        /// <typeparam name="T">The type of the object to deserialize the JSON into.</typeparam>
        /// <param name="uri">The URI to send the GET request to.</param>
        /// <returns>The deserialized object of type T.</returns>
        private async Task<T> GetAsync<T>(Uri uri)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                var json = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }

        /// <summary>
        /// Retrieves detailed information about a movie with the specified movie ID.
        /// Also calls the GetPeopleCreditsMovieAsync method to get the list of the cast and the crew.
        /// </summary>
        /// <param name="movie_id">The ID of the movie to retrieve.</param>
        /// <returns>A Task representing the asynchronous operation. The Task will contain the retrieved Movie object.</returns>
        public async Task<Movie> GetMovieAsync(int movie_id)
        {
            var uri = new Uri(serverUrl, $"movie/{movie_id}?api_key={key}");
            var movie = await GetAsync<Movie>(uri);

            var image = await GetMovieImageAsync(movie_id);
            if (image.posters.Count != 0)
            {
                string baseUrl = "https://image.tmdb.org/t/p/";
                string file_size = "w500";
                string file_path = image.posters[0].file_path;

                movie.backgroundImage = baseUrl + file_size + file_path;

            }

            PeopleCredits _credits = await GetPeopleCreditsMovieAsync(movie_id);
            movie.credits = _credits;

            return movie;
        }

        // <summary>
        /// Retrieves detailed information about a TV show with the specified series ID.
        /// Also calls the GetTVSeasonAsync method to get the list of seasons and their episodes.
        /// And the GetPeopleCreditsMovieAsync method to get the list of the cast and the crew.
        /// </summary>
        /// <param name="series_id">The ID of the TV show to retrieve.</param>
        /// <returns>A Task representing the asynchronous operation. The Task will contain the retrieved TVShow object.</returns>
        public async Task<TVShow> GetTVShowAsync(int series_id)
        {
            var uri = new Uri(serverUrl, $"tv/{series_id}?api_key={key}");
            var tvShow = await GetAsync<TVShow>(uri);

            var image = await GetTVShowImageAsync(series_id);
            if (image.posters.Count != 0)
            {
                string baseUrl = "https://image.tmdb.org/t/p/";
                string file_size = "w500";
                string file_path = image.posters[0].file_path;

                tvShow.backgroundImage = baseUrl + file_size + file_path;

            }

            var seasons = new List<TVSeason>();
            for (int i = 0; i < tvShow.number_of_seasons; i++)
            {
                var season = await GetTVSeasonAsync(series_id, i + 1);
                seasons.Add(season);
            }
            tvShow.seasons = seasons;

            PeopleCredits _credits = await GetPeopleCreditsTVShowAsync(series_id);
            tvShow.credits = _credits;

            return tvShow;
        }

        /// <summary>
        /// Retrieves detailed information about a person with the specified person ID.
        /// Also calls the GetTVShowCreditsAsync and GetMovieCreditsAsync to get the lists of Movie and TVShow Credits.
        /// </summary>
        /// <param name="person_id">The ID of the person to retrieve.</param>
        /// <returns>A Task representing the asynchronous operation. The Task will contain the retrieved Person object.</returns>
        public async Task<Person> GetPersonAsync(int person_id)
        {
            var uri = new Uri(serverUrl, $"person/{person_id}?api_key={key}");
            var person = await GetAsync<Person>(uri);

            var image = await GetPersonImageAsync(person_id);
            if (image.profiles.Count != 0)
            {
                string baseUrl = "https://image.tmdb.org/t/p/";
                string file_size = "w500";
                string file_path = image.profiles[0].file_path;

                person.backgroundImage = baseUrl + file_size + file_path;
            }

            TVCredits _tvCredits = await GetTVShowCreditsAsync(person_id);
            MovieCredits _movieCredits = await GetMovieCreditsAsync(person_id);

            person.tvCredits = _tvCredits;
            person.movieCredits = _movieCredits;

            return person;
        }

        /// <summary>
        /// Retrieves information about a specific TV season of a TV show.
        /// </summary>
        /// <param name="series_id">The ID of the TV show.</param>
        /// <param name="season_number">The number of the season.</param>
        /// <returns>The TV season information.</returns>
        public async Task<TVSeason> GetTVSeasonAsync(int series_id, int season_number)
        {
            return await GetAsync<TVSeason>(new Uri(serverUrl, $"tv/{series_id}/season/{season_number}?api_key={key}"));
        }

        /// <summary>
        /// Retrieves movie credits for a specific person.
        /// </summary>
        /// <param name="person_id">The ID of the person.</param>
        /// <returns>The movie credits of the person.</returns>
        public async Task<MovieCredits> GetMovieCreditsAsync(int person_id)
        {
            return await GetAsync<MovieCredits>(new Uri(serverUrl, $"person/{person_id}/movie_credits?api_key={key}"));
        }

        /// <summary>
        /// Retrieves TV show credits for a specific person.
        /// </summary>
        /// <param name="person_id">The ID of the person.</param>
        /// <returns>The TV show credits of the person.</returns>
        public async Task<TVCredits> GetTVShowCreditsAsync(int person_id)
        {
            return await GetAsync<TVCredits>(new Uri(serverUrl, $"person/{person_id}/tv_credits?api_key={key}"));
        }

        /// <summary>
        /// Retrieves people credits for a specific movie.
        /// </summary>
        /// <param name="movie_id">The ID of the movie.</param>
        /// <returns>The people credits of the movie.</returns>
        public async Task<PeopleCredits> GetPeopleCreditsMovieAsync(int movie_id)
        {
            return await GetAsync<PeopleCredits>(new Uri(serverUrl, $"movie/{movie_id}/credits?api_key={key}"));
        }

        /// <summary>
        /// Retrieves people credits for a specific TV show.
        /// </summary>
        /// <param name="series_id">The ID of the TV show.</param>
        /// <returns>The people credits of the TV show.</returns>
        public async Task<PeopleCredits> GetPeopleCreditsTVShowAsync(int series_id)
        {
            return await GetAsync<PeopleCredits>(new Uri(serverUrl, $"tv/{series_id}/credits?api_key={key}"));
        }

        /// <summary>
        /// Retrieves a list of movies ordered by their popularity. Page=1 means exactly 20 results.
        /// </summary>
        /// <returns>The list of popular movies.</returns>
        public async Task<MovieList> GetPopularMoviesAsync()
        {
            return await GetAsync<MovieList>(new Uri(serverUrl, $"movie/popular?page=1&api_key={key}"));
        }

        /// <summary>
        /// Retrieves a list of TV shows ordered by their popularity. Page=1 means exactly 20 results.
        /// </summary>
        /// <returns>The list of popular TV shows.</returns>
        public async Task<TVShowList> GetPopularTVShowsAsync()
        {
            return await GetAsync<TVShowList>(new Uri(serverUrl, $"tv/popular?page=1&api_key={key}"));
        }

        /// <summary>
        /// Retrieves a list of people ordered by their popularity. Page=1 means exactly 20 results.
        /// </summary>
        /// <returns>The list of popular people.</returns>
        public async Task<PersonList> GetPopularPeopleAsync()
        {
            return await GetAsync<PersonList>(new Uri(serverUrl, $"person/popular?page=1&api_key={key}"));
        }

        /// <summary>
        /// Retrieves lists of images for a specific movie. BackDrops, Logos, Posters in different sizes.
        /// </summary>
        /// <param name="movie_id">The ID of the movie.</param>
        /// <returns>The movie image.</returns>
        public async Task<Image> GetMovieImageAsync(int movie_id)
        {
            return await GetAsync<Image>(new Uri(serverUrl, $"movie/{movie_id}/images?api_key={key}"));
        }

        /// <summary>
        /// Retrieves lists of images for a specific TV show. BackDrops, Logos, Posters in different sizes.
        /// </summary>
        /// <param name="series_id">The ID of the TV show.</param>
        /// <returns>The TV show image.</returns>
        public async Task<Image> GetTVShowImageAsync(int series_id)
        {
            return await GetAsync<Image>(new Uri(serverUrl, $"tv/{series_id}/images?api_key={key}"));
        }

        /// <summary>
        /// Retrieves the profile images for a specific person.
        /// </summary>
        /// <param name="person_id">The ID of the person.</param>
        /// <returns>The person image.</returns>
        public async Task<Image> GetPersonImageAsync(int person_id)
        {
            return await GetAsync<Image>(new Uri(serverUrl, $"person/{person_id}/images?api_key={key}"));
        }

        /// <summary>
        /// Searches for movies based on the specified query. It is mostly used for keyword(s) searching.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <returns>A list of matching movies.</returns>
        public async Task<MovieList> SearchMoviesAsync(string query)
        {
            var encodedQuery = Uri.EscapeDataString(query);
            var uri = new Uri(serverUrl, $"search/movie?api_key={key}&query={encodedQuery}");
            return await GetAsync<MovieList>(uri);
        }

        /// <summary>
        /// Searches for TV shows based on the specified query. It is mostly used for keyword(s) searching.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <returns>A list of matching TV shows.</returns>
        public async Task<TVShowList> SearchTVShowsAsync(string query)
        {
            var encodedQuery = Uri.EscapeDataString(query);
            var uri = new Uri(serverUrl, $"search/tv?api_key={key}&query={encodedQuery}");
            return await GetAsync<TVShowList>(uri);
        }

        /// <summary>
        /// Searches for people based on the specified query. It is mostly used for keyword(s) searching.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <returns>A list of matching people.</returns>
        public async Task<PersonList> SearchPeopleAsync(string query)
        {
            var encodedQuery = Uri.EscapeDataString(query);
            var uri = new Uri(serverUrl, $"search/person?api_key={key}&query={encodedQuery}");
            return await GetAsync<PersonList>(uri);
        }
    }
}
