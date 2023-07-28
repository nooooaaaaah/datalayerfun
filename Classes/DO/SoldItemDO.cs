using WNBOT.Classes.DO.SavedStream;

namespace WNBOT.Classes.DO.SoldItem
{
    public class SoldItemData
    {
        public required int soldItemId { get; set; }
        public required float price { get; set; }
        public required float timeStamp { get; set; }
        public required int quantitySold { get; set; }
        public required string currency { get; set; }
        public required int orderId { get; set; }
        public required string purchaserId { get; set; }
        public required string transactionType { get; set; }
        public required string productName { get; set; }
        public int savedStreamId { get; set; }

        public SavedStreamData? savedLiveStream { get; set; }
    }
}