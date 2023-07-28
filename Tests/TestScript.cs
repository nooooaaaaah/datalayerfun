using WNBOT.Services.SoldItem;
using WNBOT.Services.Seller;
using WNBOT.Tests.Fakes;
using WNBOT.Classes.BO.Seller;

namespace WNBOT.Tests.Scripts
{
    public class TestScript
    {
        public TestScript(DatabaseContext dbContext)
        {
            GenFakes genFakes = new GenFakes();
            List<DetailedSellerBO> fakeSellers = genFakes.FakeInitialSellerList();
            // SellerService sellerService = new SellerService(dbContext);
        }
    }
}
