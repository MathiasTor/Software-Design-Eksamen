﻿using PG3302_Eksamen.Database;
using PG3302_Eksamen.Logic;
using PG3302_Eksamen.Media;
using PG3302_Eksamen.User;

namespace PG3302_Eksamen.Renting
{
    internal class RentGameDbLogic
    {
        //Field
        private DbLogicGame _dbLogicGame = new();

        //Constructor
        public RentGameDbLogic()
        {
        }

        //Methods
        //Get all games that are not rented
        public List<Game> GetRentableGames()
        {
            List<Game> games = _dbLogicGame.GetAllGames();
            List<Game> rentedGames = new();

            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                foreach (RentedMedia rm in db.RentedMedia)
                {
                    foreach (Game g in games)
                    {
                        if (!rm.IsReturned && rm.MediaId == g.Id && rm.Media == "Game")
                        {
                            rentedGames.Add(g);
                        }
                    }
                }

                foreach (Game g in rentedGames)
                {
                    games.Remove(g);
                }

                return games;
            }
        }

        //Rent game
        public void RentGame(SystemUser user, Game game)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                DateTime currentTime = DateTime.Now;
                RentedMedia rentedMedia = new("Game", game.Id, user.Name, currentTime, false);

                db.RentedMedia.Add(rentedMedia);
                db.SaveChanges();
            }
        }
    }
}
