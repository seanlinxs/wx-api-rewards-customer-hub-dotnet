using Microsoft.AspNetCore.Mvc;
using wx_api_rewards_customer_hub.Models;

namespace wx_api_rewards_customer_hub.Controllers
{
    [Route("wx/v1/loyalty/rewards/customer-hub/[controller]/[action]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICdpService _cdp;
        private readonly IOtpSerivce _otp;

        public CardsController(ICdpService cdp, IOtpSerivce otp)
        {
            _cdp = cdp;
            _otp = otp;
        }

        [HttpPost]
        public async Task<ActionResult<Response<OTPTokenDTO>>> Login(LoginMemberDTO loginMemberDTO)
        {
            var loginResultDTO = await _cdp.Login(loginMemberDTO);

            if (loginResultDTO.Result == StoredProcedureResult.Success)
            {
                Response<OTPResponseDTO>? otpResponseDTO = await _otp.SendOTP(new OTPRequestDTO(loginMemberDTO, loginResultDTO));
                return Created(string.Empty, otpResponseDTO);
            }

            return Unauthorized(new Error(loginResultDTO.ErrorCode, loginResultDTO.ErrorMessage));
        }
    }
}
