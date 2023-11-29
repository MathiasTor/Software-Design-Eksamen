﻿using PG3302_Eksamen.Database;
using PG3302_Eksamen.Logic;
using PG3302_Eksamen.Media;
using PG3302_Eksamen.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.Renting
{
    public class RentMusicDbLogic
    {
        DbLogicMusic dbLogic = new();

        public RentMusicDbLogic()
        {
        }

        internal List<Music> GetRentableMusic()
        {
            List<Music> songs = dbLogic.GetAllMusic();
            List<Music> rentedSongs = new();

            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                foreach (RentedMedia rm in db.RentedMedia)
                {
                    foreach (Music m in songs)
                    {
                        if (!rm.IsReturned && rm.MediaId == m.Id && rm.Media == "Music")
                        {
                            rentedSongs.Add(m);
                        }
                    }
                }

                foreach (Music m in rentedSongs)
                {
                    songs.Remove(m);
                }

                return songs;
            }
        }

        internal void RentMusic(SystemUser user, Music music)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                DateTime currentTime = DateTime.Now;
                RentedMedia rentedMedia = new("Music", music.Id, user.Name, currentTime, false);

                db.RentedMedia.Add(rentedMedia);
                db.SaveChanges();
            }
        }
    }
}
