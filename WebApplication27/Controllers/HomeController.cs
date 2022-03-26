using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication24.Models;
using WebApplication24.Services;

namespace WebApplication25.Controllers
{
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITestInternalService testInternalService;
        private readonly ITestService testService;
        private readonly string s;


        public HomeController(ILogger<HomeController> logger, ITestInternalService testInternalService, ITestService testService, string s)
        {
            _logger = logger;
            this.testInternalService = testInternalService;
            this.testService = testService;
            this.s = s;
        }

        [HttpGet("[action]")]
        public string Index()
        {
            testService.TestMethod();
            testService.TestMethod();
            testInternalService.TestInternalMethod();
            testInternalService.TestInternalMethod();
            return $"{StaticCounter.Counter} {StaticCounter.InternalCounter} {s}";
        }
    }
}