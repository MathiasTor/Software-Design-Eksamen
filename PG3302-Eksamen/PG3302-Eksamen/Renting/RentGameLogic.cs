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
        SystemUser _user;

        RentGameDbLogic _rentGameDbLogic = new();

        public RentGameLogic(SystemUser user)
        {
            this._user = user;
        }

        public List<Game> GetRentableGames()
        {
            return _rentGameDbLogic.GetRentableGames();
        }

        public void RentGame(Game game)
        {
            _rentGameDbLogic.RentGame(_user, game);
        }
    }
}
