using PG3302_Eksamen.Media;
using PG3302_Eksamen.UI;
using PG3302_Eksamen.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.Renting
{
    public class RentGameUI
    {
        private SystemUser _user;

        public RentGameUI(SystemUser user)
        {
            this._user = user;
        }

        internal void RentGameMenu(SystemUser user)
        {
            RentGameLogic rentGameLogic = new(user);

            List<Game> rentableGames = rentGameLogic.GetRentableGames();

            Console.Clear();

            Console.WriteLine("Rentable games:");

            foreach (Game g in rentableGames)
            {
                Console.WriteLine(rentableGames.IndexOf(g) + 1 + " - " + g);
            }

            Console.Write("Enter ID of game to rent (Back: 0): ");

            try
            {
                int gameId = Convert.ToInt32(Console.ReadLine());

                if (gameId == 0)
                {
                    Console.Clear();
                    RentMediaUI rentMediaUI1 = new();
                    rentMediaUI1.RentMediaMenu(user);
                    return;
                }

                if (gameId > rentableGames.Count)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid ID!");
                    RentGameMenu(user);
                    return;
                }

                Game gameToRent = rentableGames[gameId - 1];

                Console.Clear();

                Console.WriteLine("You have rented: " + gameToRent.Title);

                rentGameLogic.RentGame(gameToRent);

                RentMediaUI rentMediaUI = new();
                rentMediaUI.RentMediaMenu(user);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input!");
                RentGameMenu(user);
                return;
            }
        }
    }
}
