namespace PG3302_Eksamen.Media
{
    public abstract class Media
    {
        //Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Creator { get; set; }
        public int? ReleaseYear { get; set; }
        public string? Genre { get; set; }
    }
}
