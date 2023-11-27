using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PG3302_Eksamen.Database;
using PG3302_Eksamen.Logic;
using PG3302_Eksamen.User;

namespace PG3302_Eksamen.Renting
{
    public class RentMediaDbLogic
    {
        SystemUser user;

        public RentMediaDbLogic(SystemUser user)
        {
            this.user = user;
        }

        //Get all rented media for user
        public List<RentedMedia> GetRentedMedia()
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                List<RentedMedia> rentedMedia = new();

                foreach (RentedMedia media in db.RentedMedia)
                {
                    if (media.RentedBy == user.Name && !media.IsReturned)
                    {
                        rentedMedia.Add(media);
                    }
                }
                return rentedMedia;
            }
        }

        //Return rented media
        public void ReturnMedia(RentedMedia rentedMedia)
        {
            var options = MediaDbContextFactory.Options();

            using (var db = new MediaDbContext(options))
            {
                foreach (RentedMedia media in db.RentedMedia)
                {
                    if (media.Id == rentedMedia.Id && !media.IsReturned)
                    {
                        media.IsReturned = true;
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
