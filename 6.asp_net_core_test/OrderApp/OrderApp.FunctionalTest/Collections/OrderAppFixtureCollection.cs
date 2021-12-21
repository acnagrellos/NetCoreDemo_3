using OrderApp.FunctionalTest.Fixtures;
using Xunit;

namespace OrderApp.FunctionalTest.Collections
{
    [CollectionDefinition(TestConstants.TestCollectionName)]
    public class OrderAppCollection : ICollectionFixture<TestHostFixture>
    {
    }
}
