using PG3302_Eksamen.Media;
using PG3302_Eksamen.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.Renting
{
    public class RentMusicLogic
    {
        private SystemUser _user;

        private RentMusicDbLogic _rentMusicDbLogic = new();

        public RentMusicLogic(SystemUser user)
        {
            this._user = user;
        }

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
