using System.ComponentModel.DataAnnotations;

namespace wx_api_rewards_customer_hub.Models;

public class Member
{
    public string CRN { get; set; }
    public string CardNumber { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class LoginMemberDTO
{
    [Required]
    public string Preferred { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Mobile { get; set; }
}

public class OTPTokenDTO
{
    public string Token { get; set; }
}
