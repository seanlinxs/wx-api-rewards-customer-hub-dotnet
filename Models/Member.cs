using System.ComponentModel.DataAnnotations;

namespace wx_api_rewards_customer_hub.Models;

public enum PreferredDevice
{
    Email,
    Mobile
}

public enum StoredProcedureResult
{
    Success,
    Failure
}

public class LoginResultDTO
{
    public string? ErrorCode { get; set; }
    public string? ErrorMessage { get; set; }
    public StoredProcedureResult Result { get; set; }
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
    public string? Preferred { get; set; }
    public string? Email { get; set; }
    public string? Mobile { get; set; }
}
