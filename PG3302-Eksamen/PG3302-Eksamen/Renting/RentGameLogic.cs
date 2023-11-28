using PG3302_Eksamen.Media;
using PG3302_Eksamen.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.Renting
{
    public class RentGameLogic
    {
        SystemUser user;

        RentGameDbLogic rentGameDbLogic = new();

        public RentGameLogic(SystemUser user)
        {
            this.user = user;
        }

        public List<Game> GetRentableGames()
        {
            return rentGameDbLogic.GetRentableGames();
        }

        public void RentGame(Game game)
        {
            rentGameDbLogic.RentGame(user, game);
        }
    }
}
