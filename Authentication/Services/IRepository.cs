using Authentication.Models;

namespace Authentication.Services
{
    public interface IRepository
    {
        public void AddUser(User user);
        public User GetUser(string userName);
        public bool AuthenticateUser(string password, string passwordHash);
    }
}
