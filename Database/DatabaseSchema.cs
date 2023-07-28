using Microsoft.EntityFrameworkCore;
using WNBOT.Classes.DO.SavedStream;
using WNBOT.Classes.DO.Seller;
using WNBOT.Classes.DO.SoldItem;

namespace WNBOT
{
    public partial class DatabaseContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Schema shmeema
            // modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<SellerData>(entity =>
            {
                entity.ToTable("seller");
                entity.HasKey(s => s.sellerId);
            });

            modelBuilder.Entity<SavedStreamData>(entity =>
            {
                entity.ToTable("saved_streams");
                entity.HasKey(ss => ss.savedStreamId);
            });

            modelBuilder.Entity<SoldItemData>(entity =>
            {
                entity.ToTable("sold_item");
                entity.HasKey(si => si.soldItemId);
            });

            OnModelCreatingPartial(modelBuilder);
        }
    }
}