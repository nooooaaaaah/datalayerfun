using WNBOT.Classes.DO.SavedStream;

namespace WNBOT.Classes.DO.Seller
{
    public class SellerData
    {
        public required int sellerId { get; set; }
        public required string username { get; set; }
        public required float sellerRating { get; set; }
        public required int followerCount { get; set; }
        public required string bio { get; set; }
        public required int soldCount { get; set; }
        public required int numOfReviews { get; set; }
        public required int numOfSavedStreams { get; set; }
        public required int avgTotalViewers { get; set; }
        public required int itemsSoldDuringSavedStreams { get; set; }
        public required float avgPriceOfItemsSoldDuringSavedStreams { get; set; }
        public required float dateOfOldestStream { get; set; }
        public required int numOfUniquePurchasers { get; set; }
        public required int userId { get; set; }

        public ICollection<SavedStreamData>? savedLiveStreams { get; set; }
    }
}