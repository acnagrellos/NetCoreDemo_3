using OrderApp.FunctionalTest.Fixtures;
using System.Reflection;
using Xunit.Sdk;

namespace OrderApp.FunctionalTest.Fixtures.Reset
{
    public class ResetCustomersService : BeforeAfterTestAttribute
    {
        public override void Before(MethodInfo methodUnderTest)
        {
            TestHostFixture.ResetCustomerService();
        }
    }
}
