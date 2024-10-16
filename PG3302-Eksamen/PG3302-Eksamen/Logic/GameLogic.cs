using PG3302_Eksamen.Media;

namespace PG3302_Eksamen.Logic
{
    public class GameLogic
    {
        //Properties
        public List<Game> Games { get; set; }

        //Field
        readonly DbLogicGame _dbLogic;

        //Constructor
        public GameLogic(DbLogicGame dbLogicGame)
        {
            this._dbLogic = dbLogicGame;
            Games = new List<Game>();
        }

        //Methods
        //Add a game
        public void AddGame(string title, string creator, int releaseYear, string genre, string platform)
        {
            Game gameToAdd = new Game(title, creator, releaseYear, genre, platform);

            Games.Add(gameToAdd);
            Console.WriteLine($"Game {title} has been added!");
            
            _dbLogic.AddGameToDb(gameToAdd);

        }

        //Remove a Game
        public void RemoveGame(Game game)
        {
            Games.Remove(game);
            DbLogicGame.DeleteGameFromDb(game);
        }

        //Print all games
        public void DisplayGames()
        {
            _dbLogic.PrintAllGamesFromDb();
        }

        //Edit game title
        public void EditGameTitle(Game game, String newTitle)
        {
            game.Title = newTitle;
            DbLogicGame.EditGameTitle(game, newTitle);
        }

        //Edit game creator
        public void EditGameCreator(Game game, String newCreator)
        {
            game.Creator = newCreator;
            DbLogicGame.EditGameCreator(game, newCreator);
        }

        //Edit game release year
        public void EditGameReleaseYear(Game game, int newReleaseYear)
        {
            game.ReleaseYear = newReleaseYear;
            DbLogicGame.EditGameReleaseYear(game, newReleaseYear);
        }

        //Edit game platform
        public void EditGamePlatform(Game game, String newPlatform)
        {
            game.Platform = newPlatform;
            DbLogicGame.EditGamePlatform(game, newPlatform);
        }

        //Edit game genre
        public void EditGameGenre(Game game, String newGenre)
        {
            game.Genre = newGenre;
            DbLogicGame.EditGameGenre(game, newGenre);
        }


    }
}