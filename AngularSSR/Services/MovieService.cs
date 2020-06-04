using AngularSSR.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularSSR.Services
{
    public class MovieService
    {
        private readonly IMongoCollection<Movie> _movies;

        public MovieService(IMovieDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _movies = database.GetCollection<Movie>(settings.MoviesCollectionName);
        }

        public List<Movie> Get() => _movies.Find(movie => true).ToList();

        public Movie Get(string id) => _movies.Find<Movie>(movie => movie.Id == id).FirstOrDefault();

        public Movie Create(Movie movie)
        {
            _movies.InsertOne(movie);
            return movie;
        }

        public void Update(string id, Movie movie) => _movies.ReplaceOne(m => m.Id == id, movie);

        public void Remove(Movie movieIn) => _movies.DeleteOne(movie => movie.Id == movieIn.Id);

    }
}
