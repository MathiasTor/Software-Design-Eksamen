using PG3302_Eksamen.Media;
using PG3302_Eksamen.User;

namespace PG3302_Eksamen.Renting
{
    public class RentGameLogic
    {
        //Fields
        private SystemUser _user;
        private RentGameDbLogic _rentGameDbLogic = new();

        //Constructor
        public RentGameLogic(SystemUser user)
        {
            this._user = user;
        }

        //Methods
        //Get all games that are not rented
        public List<Game> GetRentableGames()
        {
            return _rentGameDbLogic.GetRentableGames();
        }

        //Rent game
        public void RentGame(Game game)
        {
            _rentGameDbLogic.RentGame(_user, game);
        }
    }
}
