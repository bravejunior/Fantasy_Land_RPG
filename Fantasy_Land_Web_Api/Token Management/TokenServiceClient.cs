using Fantasy_Land_Web_Api.Interfaces;
using Models.DTOs;

namespace Fantasy_Land_Web_Api.Token_Management
{
    public class TokenServiceClient : ITokenService
    {
        public AuthResult GenerateAccessToken(User user)
        {
            throw new NotImplementedException();
        }

        public string GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAccessTokenAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<RefreshToken> GetRefreshTokenAsync(string userid)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResult> RefreshAccessTokenAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> RefreshRefreshTokenAsync(string userid, string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<RefreshToken> UpdateRefreshTokenAsync(string userid)
        {
            throw new NotImplementedException();
        }
    }
}
