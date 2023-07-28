using Bogus;
using WNBOT.Classes.BO.Seller;

namespace WNBOT.Tests.FakeObj
{
    public class FakeSeller : Faker<DetailedSellerBO>
    {
        public FakeSeller()
        {
            Initialize();
            // AdditionalInfo();
        }

        public void Initialize()
        {
            RuleFor(s => s.sellerId, f => f.Random.Int());
            RuleFor(s => s.userId, f => f.Random.Int());
            RuleFor(s => s.username, f => f.Person.UserName);
        }
        public void AdditionalInfo()
        {
            RuleFor(s => s.sellerRating, f => f.Random.Float(0, 5));
            RuleFor(s => s.followerCount, f => f.Random.Int(0, 100000));
            RuleFor(s => s.bio, f => f.Lorem.Sentence());
            RuleFor(s => s.soldCount, f => f.Random.Int(0, 1000));
            RuleFor(s => s.numOfReviews, f => f.Random.Int(0, 100));
            RuleFor(s => s.numOfSavedStreams, f => f.Random.Int(0, 100));
            RuleFor(s => s.avgTotalViewers, f => f.Random.Int(0, 1000));
            RuleFor(s => s.itemsSoldDuringSavedStreams, f => f.Random.Int(0, 100));
            RuleFor(s => s.avgPriceOfItemsSoldDuringSavedStreams, f => f.Random.Float(0, 100));
            RuleFor(s => s.dateOfOldestStream, f => f.Random.Int(0, 100));
            RuleFor(s => s.numOfUniquePurchasers, f => f.Random.Int(0, 100));
        }
    }
}

