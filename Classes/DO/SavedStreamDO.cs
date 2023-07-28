using WNBOT.Classes.DO.SoldItem;
using WNBOT.Classes.DO.Seller;

namespace WNBOT.Classes.DO.SavedStream
{
    public class SavedStreamData
    {
        public int savedStreamId { get; set; }
        public required string streamKey { get; set; }
        public required float startTime { get; set; }
        public required int viewers { get; set; }
        public required string category { get; set; }
        public required int sellerId { get; set; }
        public SellerData? seller { get; set; }
        public ICollection<SoldItemData>? soldItems { get; set; }
    }
}