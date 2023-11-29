using PG3302_Eksamen.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.Logic
{
    public class MovieLogic
    {
        //Properties
        public List<Movie> Movies { get; set;}

        //Field
        readonly DbLogicMovie _dbLogicMovie;

        //Constructor
        public MovieLogic(DbLogicMovie dbLogicMovie)
        {
            this._dbLogicMovie = dbLogicMovie;
            Movies = new();
        }

        //Methods
        //Add a movie
        public void AddMovie(string title, string creator, int releaseYear, string genre, int lengthInMinutes)
        {
            Movie movieToAdd = new(title, creator, releaseYear, genre, lengthInMinutes);

            Movies.Add(movieToAdd);
            Console.WriteLine($"Movie {title} has been added!");
            
            _dbLogicMovie.AddMovieToDb(movieToAdd);
        }

        //Remove a movie
        public void RemoveMovie(Movie movie)
        {
            Movies.Remove(movie);
            DbLogicMovie.DeleteMovieFromDb(movie);
        }

        //Print all movies
        public void DisplayMovies()
        {
            _dbLogicMovie.PrintAllMoviesFromDb();
        }

        //Edit movie title
        public void EditMovieTitle(Movie movie, String newTitle)
        {
            movie.Title = newTitle;
            DbLogicMovie.EditMovieTitle(movie, newTitle);
        }

        //Edit movie creator
        public void EditMovieCreator(Movie movie, String newCreator)
        {
            movie.Creator = newCreator;
            DbLogicMovie.EditMovieCreator(movie, newCreator);
        }

        //Edit movie length
        public void EditMovieLength(Movie movie, int newLength)
        {
            movie.LengthInMinutes = newLength;
            DbLogicMovie.EditMovieLength(movie, newLength);
        }

        //Edit movie genre
        public void EditMovieGenre(Movie movie, String newGenre)
        {
            movie.Genre = newGenre;
            DbLogicMovie.EditMovieGenre(movie, newGenre);
        }

        //Edit movie release year
        public void EditMovieReleaseYear(Movie movie, int newReleaseYear)
        {
            movie.ReleaseYear = newReleaseYear;
            DbLogicMovie.EditMovieReleaseYear(movie, newReleaseYear);
        }
    }
}
