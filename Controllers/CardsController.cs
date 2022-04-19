using Microsoft.AspNetCore.Mvc;
using wx_api_rewards_customer_hub.Models;

namespace wx_api_rewards_customer_hub.Controllers
{
    [Route("wx/v1/loyalty/rewards/customer-hub/[controller]/[action]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Response<OTPTokenDTO>>> Login(LoginMemberDTO loginMemberDTO)
        {
            OTPTokenDTO result = new OTPTokenDTO
            {
                Token = "TEST OTP Token"
            };
            return Created(string.Empty, new Response<OTPTokenDTO>
            {
                Data = result
            });
        }
    }
}
