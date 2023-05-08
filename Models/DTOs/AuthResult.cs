namespace Models.DTOs
{
    public class AuthResult
    {
        public bool Result { get; set; }
        public List<string> Errors { get; set; }
        public string AccessToken { get; set; }
        public string Username { get; set; }
    }
}