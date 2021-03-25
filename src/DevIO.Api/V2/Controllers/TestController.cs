using DevIO.Api.Controllers;
using DevIO.Business.Intefaces;
using Elmah.Io.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace DevIO.Api.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/test")]
    public class TestController : MainController
    {
        private readonly ILogger _logger;

        public TestController(INotificador notificador, 
                              IUser appUser,
                              ILogger<TestController> logger) : base(notificador, appUser)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Value()
        {
            //throw new Exception(message: "Error");

            //try
            //{
            //    var i = 0;
            //    var result = 42 / i;
            //}
            //catch (DivideByZeroException e)
            //{
            //    e.Ship(HttpContext);
            //}

            _logger.LogTrace("My Log Trace"); // For development (Disabled)
            _logger.LogDebug("My Log Debug"); // For development (Disabled)
            _logger.LogInformation("My Log Information");
            _logger.LogWarning("My Log Warning");
            _logger.LogError("My Log Error");
            _logger.LogCritical("My Log Critical");

            return "I am V2";
        }
    }
}
