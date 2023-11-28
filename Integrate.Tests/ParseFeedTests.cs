using Integrate.Bll.MainLogic;

namespace Integrate.Tests
{
    [TestClass]
    public class ParseFeedTests
    {
        [TestMethod]
        public void TestParseFeed()
        {
            FeedData feedData = new FeedData();

            feedData.RunParses();
        }
    }
}