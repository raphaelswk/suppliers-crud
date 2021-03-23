using DevIO.Api.Controllers;
using DevIO.Business.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/test")]
    public class TestController : MainController
    {
        public TestController(INotificador notificador, IUser appUser) 
            : base(notificador, appUser)
        {
        }

        [HttpGet]
        public string Value()
        {
            return "I am V2";
        }
    }
}
