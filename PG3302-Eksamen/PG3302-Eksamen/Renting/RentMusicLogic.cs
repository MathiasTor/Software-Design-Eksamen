using PG3302_Eksamen.Media;
using PG3302_Eksamen.User;

namespace PG3302_Eksamen.Renting
{
    public class RentMusicLogic
    {
        //Field
        private SystemUser _user;

        private RentMusicDbLogic _rentMusicDbLogic = new();

        //Constructor
        public RentMusicLogic(SystemUser user)
        {
            this._user = user;
        }

        //Methods
        public List<Music> GetRentableMusic()
        {
            return _rentMusicDbLogic.GetRentableMusic();
        }

        public void RentMusic(Music music)
        {
            _rentMusicDbLogic.RentMusic(_user, music);
        }
    }
}
