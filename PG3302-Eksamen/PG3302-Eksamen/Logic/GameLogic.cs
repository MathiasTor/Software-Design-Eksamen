using PG3302_Eksamen.Media;

namespace PG3302_Eksamen.Logic
{
    public class GameLogic
    {
        public List<Game> Games { get; set; }
        DbLogic DbLogic = new();

        public GameLogic()
        {
            Games = new List<Game>();
        }

        //Add a game
        public void AddGame(string title, string creator, int releaseYear, string genre, string platform)
        {
            Game gameToAdd = new Game(title, creator, releaseYear, genre, platform);

            Games.Add(gameToAdd);
            Console.WriteLine($"Game {title} has been added!");
            
            DbLogic.AddGameToDb(gameToAdd);

        }

        //Remove a Game
        public void RemoveGame(String title)
        {
            Games.RemoveAll(game => game.Title == title);
        }

        //Print all games
        public void DisplayGames()
        {
            DbLogic.PrintAllGamesFromDb();
        }
        
        //check if the game exists - return true/false

        public bool CheckIfGameExists(string title)
        {
            foreach (Game game in Games)
            {
                if (game.Title == title)
                {
                    return true;
                }
            }

            return false;
        }
        
        //Edit game title - takes in the old title and new title

        public void EditGameTitle(string title, string newTitle)
        {
            for (int i = 0; i < Games.Count; i++)
            {
                if (Games[i].Title == title)
                {
                    Games[i].Title = newTitle;
                }
            }
        }

    }
}