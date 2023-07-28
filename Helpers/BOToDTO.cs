using WNBOT.Classes.DTO.Seller;
using WNBOT.Classes.BO.Seller;

namespace WNBOT.Helpers.BOToDTO
{
    public class ToDTO
    {
        public SellerDto MapSellerBOToDto(DetailedSellerBO seller)
        {
            return new SellerDto
            {
                sellerId = seller.sellerId,
                username = seller.username,
                bio = seller.bio,
                sellerRating = seller.sellerRating,
                followerCount = seller.followerCount,
                soldCount = seller.soldCount,
                numOfReviews = seller.numOfReviews,
                numOfSavedStreams = seller.numOfSavedStreams,
                avgTotalViewers = seller.avgTotalViewers,
                itemsSoldDuringSavedStreams = seller.itemsSoldDuringSavedStreams,
                avgPriceOfItemsSoldDuringSavedStreams = seller.avgPriceOfItemsSoldDuringSavedStreams,
                dateOfOldestStream = seller.dateOfOldestStream,
                numOfUniquePurchasers = seller.numOfUniquePurchasers,
                userId = seller.userId
            };
        }
    }
}