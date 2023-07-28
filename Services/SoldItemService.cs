using WNBOT.Classes.DO.SoldItem;
using WNBOT.Classes.DTO.SoldItem;

namespace WNBOT.Services.SoldItem
{
    public class SoldItemService
    {
        private readonly DatabaseContext _dbContext;

        public SoldItemService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<SoldItemDTO>? GetAllSoldItems()
        {
            if (_dbContext.SoldItems == null)
            {
                return null;
            }
            List<SoldItemData> soldItems = _dbContext.SoldItems.ToList();
            return soldItems.Select(MapSoldItemDOToDTO).ToList();
        }
        public SoldItemDTO? GetSoldItemById(int soldItemId)
        {
            if (_dbContext.SoldItems == null)
            {
                return null;
            }
            SoldItemData? soldItem = _dbContext.SoldItems.FirstOrDefault(s => s.soldItemId == soldItemId);
            return soldItem != null ? MapSoldItemDOToDTO(soldItem) : null;
        }
        public bool AddSoldItem(SoldItemDTO soldItemDto)
        {
            if (_dbContext.SoldItems == null)
            {
                return false;
            }
            SoldItemData soldItem = MapSoldItemDTOToDO(soldItemDto);
            _dbContext.SoldItems.Add(soldItem);
            _dbContext.SaveChanges();
            return true;
        }
        public bool UpdateSoldItem(SoldItemDTO soldItemDto)
        {
            if (_dbContext.SoldItems == null)
            {
                return false;
            }
            SoldItemData? existingSoldItem = _dbContext.SoldItems.FirstOrDefault(s => s.soldItemId == soldItemDto.soldItemId);
            if (existingSoldItem != null)
            {
                existingSoldItem.price = soldItemDto.price;
                existingSoldItem.timeStamp = soldItemDto.timeStamp;
                existingSoldItem.quantitySold = soldItemDto.quantitySold;
                existingSoldItem.currency = soldItemDto.currency;
                existingSoldItem.orderId = soldItemDto.orderId;
                existingSoldItem.purchaserId = soldItemDto.purchaserId;
                existingSoldItem.transactionType = soldItemDto.transactionType;
                existingSoldItem.productName = soldItemDto.productName;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteSoldItem(int soldItemId)
        {
            if (_dbContext.SoldItems == null)
            {
                return false;
            }
            SoldItemData? soldItem = _dbContext.SoldItems.FirstOrDefault(s => s.soldItemId == soldItemId);
            if (soldItem != null)
            {
                _dbContext.SoldItems.Remove(soldItem);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        private SoldItemDTO MapSoldItemDOToDTO(SoldItemData soldItem)
        {
            return new SoldItemDTO
            {
                soldItemId = soldItem.soldItemId,
                price = soldItem.price,
                timeStamp = soldItem.timeStamp,
                quantitySold = soldItem.quantitySold,
                currency = soldItem.currency,
                orderId = soldItem.orderId,
                purchaserId = soldItem.purchaserId,
                transactionType = soldItem.transactionType,
                productName = soldItem.productName,
                savedStreamId = soldItem.savedStreamId,
            };
        }

        private static SoldItemData MapSoldItemDTOToDO(SoldItemDTO soldItem)
        {
            return new SoldItemData
            {
                soldItemId = soldItem.soldItemId,
                price = soldItem.price,
                timeStamp = soldItem.timeStamp,
                quantitySold = soldItem.quantitySold,
                currency = soldItem.currency,
                orderId = soldItem.orderId,
                purchaserId = soldItem.purchaserId,
                transactionType = soldItem.transactionType,
                productName = soldItem.productName,
                savedStreamId = soldItem.savedStreamId,
            };
        }
    }
}