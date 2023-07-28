using Microsoft.EntityFrameworkCore;
using WNBOT.Classes.DO.Seller;
using WNBOT.Classes.DO.SoldItem;
using WNBOT.Classes.DO.SavedStream;

namespace WNBOT
{
    public partial class DatabaseContext : DbContext
    {
        public DbSet<SellerData>? Sellers { get; set; }
        public DbSet<SavedStreamData>? SavedStreams { get; set; }
        public DbSet<SoldItemData>? SoldItems { get; set; }

        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Database/database.db");
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
