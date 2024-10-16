﻿using PG3302_Eksamen.Media;
using PG3302_Eksamen.User;

namespace PG3302_Eksamen.Renting
{
    public class RentMusicUI
    {
        //Field
        private SystemUser _user;

        //Constructor
        public RentMusicUI(SystemUser user)
        {
            this._user = user;
        }

        //Methods
        internal void RentMusicMenu(SystemUser user)
        {
            RentMusicLogic rentMusicLogic = new(user);
            List<Music> rentableMusic = rentMusicLogic.GetRentableMusic();

            Console.Clear();

            Console.WriteLine("Rentable Music:");
            foreach (Music m in rentableMusic)
            {
                Console.WriteLine(rentableMusic.IndexOf(m)+1 + " - " + m);
            }

            Console.Write("Enter ID of music to rent (Back: 0): ");

            try
            {
                int musicID = Convert.ToInt32(Console.ReadLine());

                if(musicID == 0)
                {
                    Console.Clear();
                    RentMediaUI rentMediaUI1 = new();
                    rentMediaUI1.RentMediaMenu(user);
                    return;
                }

                if (musicID > rentableMusic.Count)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid ID!");
                    RentMusicMenu(user);
                    return;
                }

                Music musicToRent = rentableMusic[musicID-1];

                Console.Clear();
                Console.WriteLine("You have rented: " + musicToRent.Title);
                rentMusicLogic.RentMusic(musicToRent);

                RentMediaUI rentMediaUI = new();
                rentMediaUI.RentMediaMenu(user);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input!");
                RentMusicMenu(user);
                return;
            }
        }
    }
}
