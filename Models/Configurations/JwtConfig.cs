namespace Models.Configurations
{
    public class JwtConfig
    {
        public string Secret { get; set; }
        public int AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }
    }
}
