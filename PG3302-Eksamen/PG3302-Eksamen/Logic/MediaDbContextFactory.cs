using Microsoft.EntityFrameworkCore;
using PG3302_Eksamen.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.Logic
{
    public abstract class MediaDbContextFactory
    {
        public static DbContextOptions<MediaDbContext> Options()
        {
            return new DbContextOptionsBuilder<MediaDbContext>()
                .UseSqlite(@"Data Source = .\Resources\Media.db")
                .Options;
        }
    }
}
