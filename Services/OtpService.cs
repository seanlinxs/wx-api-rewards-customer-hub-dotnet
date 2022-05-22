using wx_api_rewards_customer_hub.Models;

public interface IOtpService
{
    Task<Response<OTPResponseDTO>?> SendOTP(OTPRequestDTO otpRequestDTO);
}

public class OtpService : IOtpService
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _client;

    public OtpService(IConfiguration configuration)
    {
        _configuration = configuration;
        _client = new HttpClient();
        _client.DefaultRequestHeaders.Add("client_id", _configuration["MANDY_CLIENT_ID"]);
    }

    public async Task<Response<OTPResponseDTO>?> SendOTP(OTPRequestDTO otpRequestDTO)
    {
        var resp = await _client.PostAsJsonAsync(_configuration["OTP_HANDLER_CREATEOTP_URL"], otpRequestDTO);
        resp.EnsureSuccessStatusCode();
        
        return await resp.Content.ReadFromJsonAsync<Response<OTPResponseDTO>>();
    }
}