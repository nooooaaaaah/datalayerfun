
namespace WNBOT.Classes.BO.SoldItem
{
    public class SoldItemBO
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
        public required int savedStreamId { get; set; }
    }
}