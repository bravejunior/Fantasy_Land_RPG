using Models.DTOs;

namespace Fantasy_Land_Web_Api.Interfaces
{
    public interface ITokenService
    {
        Task<string> GetAccessTokenAsync(string refreshToken);
        Task<AuthResult> RefreshAccessTokenAsync(string refreshToken);
        Task<RefreshToken> GetRefreshTokenAsync(string userid);
        Task<string> RefreshRefreshTokenAsync(string userid, string refreshToken);
        string GenerateRefreshToken();
        Task<RefreshToken> UpdateRefreshTokenAsync(string userid);
        AuthResult GenerateAccessToken(User user);

    }
}
