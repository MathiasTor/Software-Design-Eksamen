using Microsoft.EntityFrameworkCore;
using PG3302_Eksamen.Database;

namespace PG3302_Eksamen.Logic
{
    public abstract class MediaDbContextFactory
    {

        //Methods
        public static DbContextOptions<MediaDbContext> Options()
        {
            return new DbContextOptionsBuilder<MediaDbContext>()
                .UseSqlite(@"Data Source = .\Resources\Media.db")
                .Options;
        }
    }
}
