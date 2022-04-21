using Npgsql;
using wx_api_rewards_customer_hub.Models;

public enum CDP_SOURCE
{
    CPORTAL = 1,
    MANDY = 2
}

public interface ICdpService
{
    Task<LoginResultDTO> Login(LoginMemberDTO loginRequestDTO);
}

public class CdpService : ICdpService
{
    private readonly IConfiguration _configuration;
    private readonly string _connString;

    public CdpService(IConfiguration configuration)
    {
        _configuration = configuration;
        var host = _configuration["CDP:Host"];
        var port = _configuration["CDP:Port"];
        var database = _configuration["CDP:Database"];
        var username = _configuration["CDP:Username"];
        var password = _configuration["CDP:Password"];
        _connString = $"Host={host};Port={port};Database={database};Username={username};Password={password}";
    }

    public async Task<LoginResultDTO> Login(LoginMemberDTO loginRequestDTO)
    {
        await using var _conn = new NpgsqlConnection(_connString);
        await _conn.OpenAsync();

        await using var cmd = new NpgsqlCommand("SELECT * FROM rtapi.sp_get_mandy_order_card($1, $2, $3, $4, $5, $6)", _conn);
        cmd.Parameters.AddWithValue(loginRequestDTO.Preferred == PreferredDevice.Email.ToString() ? loginRequestDTO.Email : DBNull.Value);
        cmd.Parameters.AddWithValue(loginRequestDTO.Preferred == PreferredDevice.Mobile.ToString() ? loginRequestDTO.Mobile : DBNull.Value);
        cmd.Parameters.AddWithValue(DateTime.Now);
        cmd.Parameters.AddWithValue((int)CDP_SOURCE.CPORTAL);
        cmd.Parameters.AddWithValue(CDP_SOURCE.CPORTAL.ToString());
        cmd.Parameters.AddWithValue(DBNull.Value);

        await using var reader = await cmd.ExecuteReaderAsync();

        await reader.ReadAsync();
        return new LoginResultDTO
        {
            ErrorCode = reader.IsDBNull(0) ? null : reader.GetString(0),
            ErrorMessage = reader.IsDBNull(1) ? null : reader.GetString(1),
            Result = (StoredProcedureResult)(reader.GetFieldValue<int>(2)),
            CRN = reader.IsDBNull(3) ? null : reader.GetString(3),
            CardNumber = reader.IsDBNull(4) ? null : reader.GetString(4),
            Email = reader.IsDBNull(5) ? null : reader.GetString(5),
            Mobile = reader.IsDBNull(6) ? null : reader.GetString(6),
            FirstName = reader.IsDBNull(7) ? null : reader.GetString(7),
            LastName = reader.IsDBNull(8) ? null : reader.GetString(8)
        };
    }
}