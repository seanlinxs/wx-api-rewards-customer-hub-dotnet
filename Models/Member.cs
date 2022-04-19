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
    public string Preferred { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
}

public class OTPToken
{
    public string Token { get; set; }
}
