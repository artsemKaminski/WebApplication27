using WebApplication24.Models;

namespace WebApplication24.Services
{
    public class TestService : ITestService
    {
        private readonly ITestInternalService testInternalService;
        public TestService(ITestInternalService testInternalService)
        {
            StaticCounter.Counter++;
            this.testInternalService = testInternalService;
        }

        public void TestMethod()
        {
            testInternalService.TestInternalMethod();
        }
    }
}
