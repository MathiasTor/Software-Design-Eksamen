using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.Renting
{
    [Table("RentedMedia")]
    public class RentedMedia
    {
        public int Id { get; set; }
        public string Media { get; set; }
        public int MediaId { get; set; }
        public string RentedBy { get; set; }
        public DateTime RentedDate { get; set; }
        public bool IsReturned { get; set; }

        public RentedMedia(string media, int mediaID, string rentedBy, DateTime rentedDate, bool isReturned)
        {
            Media = media;
            MediaId = mediaID;
            RentedBy = rentedBy;
            RentedDate = rentedDate;
            IsReturned = isReturned;
        }

        public RentedMedia() { }
    }
}
