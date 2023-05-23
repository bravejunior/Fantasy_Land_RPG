using Models.Entities;

namespace Fantasy_Land_Web_Client.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetCurrentUserAsync();
    }
}
