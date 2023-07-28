using WNBOT.Classes.BO.Seller;
using WNBOT.Tests.FakeObj;
namespace WNBOT.Tests.Fakes
{
    public class GenFakes
    {
        private FakeSeller _fakeSeller;
        public GenFakes()
        {
            _fakeSeller = new FakeSeller();
            _fakeSeller.Initialize();
        }
        public List<DetailedSellerBO> FakeInitialSellerList(int amount = 100)
        {
            return _fakeSeller.Generate(amount);
        }
        public List<DetailedSellerBO> AdditionalSellerInfo(List<SellerBO> sellers)
        {
            List<DetailedSellerBO> detailedSellers = sellers.Select(seller => new DetailedSellerBO(seller)).ToList();
            return detailedSellers;
        }
    }
}