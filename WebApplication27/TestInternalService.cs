using WebApplication24.Models;

namespace WebApplication24.Services
{
    public class TestInternalService : ITestInternalService
    {
        public TestInternalService()
        {
            StaticCounter.InternalCounter++;
        }

        public void TestInternalMethod()
        {
            
        }
    }
}
