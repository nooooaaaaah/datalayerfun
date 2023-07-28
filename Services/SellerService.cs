using WNBOT.Classes.DO.Seller;
using WNBOT.Classes.DTO.Seller;

namespace WNBOT.Services.Seller
{
    public class SellerService
    {
        private readonly DatabaseContext _dbContext;
        public SellerService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<SellerDto>? GetAllSellers()
        {
            if (_dbContext.Sellers == null)
            {
                return null;
            }
            List<SellerData> sellers = _dbContext.Sellers.ToList();
            return sellers.Select(MapSellerDOToDTO).ToList();
        }
        public SellerDto? GetSellerById(int sellerId)
        {
            if (_dbContext.Sellers == null)
            {
                return null;
            }
            SellerData? seller = _dbContext.Sellers.FirstOrDefault(s => s.sellerId == sellerId);
            return seller != null ? MapSellerDOToDTO(seller) : null;
        }

        public bool AddSeller(SellerDto sellerDto)
        {
            if (_dbContext.Sellers == null)
            {
                return false;
            }
            SellerData seller = MapSellerDTOToDO(sellerDto);
            _dbContext.Sellers.Add(seller);
            _dbContext.SaveChanges();
            return true;
        }
        public bool UpdateSeller(SellerDto sellerDto)
        {
            if (_dbContext.Sellers == null)
            {
                return false;
            }
            SellerData? existingSeller = _dbContext.Sellers.FirstOrDefault(s => s.sellerId == sellerDto.sellerId);
            if (existingSeller != null)
            {
                existingSeller.username = sellerDto.username;
                existingSeller.sellerRating = sellerDto.sellerRating;
                existingSeller.followerCount = sellerDto.followerCount;
                existingSeller.soldCount = sellerDto.soldCount;
                existingSeller.numOfReviews = sellerDto.numOfReviews;
                existingSeller.numOfSavedStreams = sellerDto.numOfSavedStreams;
                existingSeller.avgTotalViewers = sellerDto.avgTotalViewers;
                existingSeller.itemsSoldDuringSavedStreams = sellerDto.itemsSoldDuringSavedStreams;
                existingSeller.avgPriceOfItemsSoldDuringSavedStreams = sellerDto.avgPriceOfItemsSoldDuringSavedStreams;
                existingSeller.dateOfOldestStream = sellerDto.dateOfOldestStream;
                existingSeller.numOfUniquePurchasers = sellerDto.numOfUniquePurchasers;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteSeller(int sellerId)
        {
            if (_dbContext.Sellers == null)
            {
                return false;
            }
            SellerData? seller = _dbContext.Sellers.FirstOrDefault(s => s.sellerId == sellerId);
            if (seller != null)
            {
                _dbContext.Sellers.Remove(seller);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        private static SellerDto MapSellerDOToDTO(SellerData seller)
        {
            return new SellerDto
            {
                sellerId = seller.sellerId,
                username = seller.username,
                sellerRating = seller.sellerRating,
                bio = seller.bio,
                followerCount = seller.followerCount,
                soldCount = seller.soldCount,
                numOfReviews = seller.numOfReviews,
                numOfSavedStreams = seller.numOfSavedStreams,
                avgTotalViewers = seller.avgTotalViewers,
                itemsSoldDuringSavedStreams = seller.itemsSoldDuringSavedStreams,
                avgPriceOfItemsSoldDuringSavedStreams = seller.avgPriceOfItemsSoldDuringSavedStreams,
                dateOfOldestStream = seller.dateOfOldestStream,
                numOfUniquePurchasers = seller.numOfUniquePurchasers,
                userId = seller.userId,
            };
        }

        private static SellerData MapSellerDTOToDO(SellerDto sellerDTO)
        {
            return new SellerData
            {
                sellerId = sellerDTO.sellerId,
                bio = sellerDTO.bio,
                username = sellerDTO.username,
                sellerRating = sellerDTO.sellerRating,
                followerCount = sellerDTO.followerCount,
                soldCount = sellerDTO.soldCount,
                numOfReviews = sellerDTO.numOfReviews,
                numOfSavedStreams = sellerDTO.numOfSavedStreams,
                avgTotalViewers = sellerDTO.avgTotalViewers,
                itemsSoldDuringSavedStreams = sellerDTO.itemsSoldDuringSavedStreams,
                avgPriceOfItemsSoldDuringSavedStreams = sellerDTO.avgPriceOfItemsSoldDuringSavedStreams,
                dateOfOldestStream = sellerDTO.dateOfOldestStream,
                numOfUniquePurchasers = sellerDTO.numOfUniquePurchasers,
                userId = sellerDTO.userId,
            };
        }
    }
}