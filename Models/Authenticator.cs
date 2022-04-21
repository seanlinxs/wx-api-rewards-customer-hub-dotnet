namespace wx_api_rewards_customer_hub.Models;

public class OTPRequestDTO
{
    public string SendTo { get; set; } = null!;
    public string? MobilePhone { get; set; }
    public string? Email { get; set; }
    public string? CRN { get; set; }
    public string? FirstName { get; set; }

    public OTPRequestDTO(LoginMemberDTO loginMemberDTO, LoginResultDTO loginResultDTO)
    {
        SendTo = loginMemberDTO.Preferred.ToString();
        MobilePhone = loginResultDTO.Mobile;
        Email = loginResultDTO.Email;
        CRN = loginResultDTO.CRN;
        FirstName = loginResultDTO.FirstName;
    }
}