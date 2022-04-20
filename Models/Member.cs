using System.ComponentModel.DataAnnotations;

namespace wx_api_rewards_customer_hub.Models;

public enum PreferredDevice
{
    Email,
    Mobile
}

public class LoginResultDTO
{
    public string? ErrorCode { get; set; }
    public string? ErrorMessage { get; set; }
    public int Result { get; set; }
    public string? CRN { get; set; }
    public string? CardNumber { get; set; }
    public string? Email { get; set; }
    public string? Mobile { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}

public class LoginMemberDTO
{
    [Required]
    public PreferredDevice Preferred { get; set; }
    public string Email { get; set; } = null!;
    public string Mobile { get; set; } = null!;
}

public class OTPTokenDTO
{
    public string? Token { get; set; }
}
