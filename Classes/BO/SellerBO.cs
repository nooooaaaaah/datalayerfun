namespace WNBOT.Classes.BO.Seller
{
    public class SellerBO
    {
        public SellerBO(int sellerId, int userId, string username)
        {
            this.sellerId = sellerId;
            this.userId = userId;
            this.username = username;
        }

        public required int sellerId { get; set; }
        public required int userId { get; set; }
        public required string username { get; set; }
    }

    public class DetailedSellerBO : SellerBO
    {
        public DetailedSellerBO(SellerBO seller)
            : base(seller.sellerId, seller.userId, seller.username) { }

        public required float sellerRating { get; set; }
        public required int followerCount { get; set; }
        public required string bio { get; set; }
        public required int soldCount { get; set; }
        public required int numOfReviews { get; set; }
        public required int numOfSavedStreams { get; set; }
        public required int avgTotalViewers { get; set; }
        public required int itemsSoldDuringSavedStreams { get; set; }
        public required float avgPriceOfItemsSoldDuringSavedStreams { get; set; }
        public required int dateOfOldestStream { get; set; }
        public required int numOfUniquePurchasers { get; set; }
    }
}
