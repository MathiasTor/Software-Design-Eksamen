using System.ComponentModel.DataAnnotations.Schema;

namespace PG3302_Eksamen.Renting
{
    [Table("RentedMedia")]
    public class RentedMedia
    {
        //Properties
        public int Id { get; set; }
        public string Media { get; set; }
        public int MediaId { get; set; }
        public string RentedBy { get; set; }
        public DateTime RentedDate { get; set; }
        public bool IsReturned { get; set; }

        //Constructor
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
