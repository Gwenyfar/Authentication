using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Authorize]
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticaionController : ControllerBase
    {
        public AuthenticaionController()
        {
                
        }
        [HttpPost]
        public IActionResult SignIn(SignInDto signIn)
        {

        }
    }
}
