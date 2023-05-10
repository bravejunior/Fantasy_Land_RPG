using Models.DTOs;

namespace Fantasy_Land_Web_Api.Interfaces
{
    public interface ITokenService
    {
        Task<AuthResult> RefreshAccessTokenAsync(string refreshToken);
        Task<RefreshToken> GetRefreshTokenAsync(string userid);
        string GenerateRefreshToken();
        Task<RefreshToken> UpdateRefreshTokenAsync(string userid);
        AuthResult GenerateAccessToken(User user);

    }
}
