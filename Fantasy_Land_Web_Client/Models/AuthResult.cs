namespace Fantasy_Land_Web_Client.Models
{
    public class AuthResult
    {
        public bool Result { get; set; }
        public List<string> Errors { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
    }
}
