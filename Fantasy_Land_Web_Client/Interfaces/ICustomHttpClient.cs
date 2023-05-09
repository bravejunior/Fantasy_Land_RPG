namespace Fantasy_Land_Web_Client.Interfaces
{
    public interface ICustomHttpClient
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}
