using Authentication.Models;

namespace Authentication.Services
{
    public class Repository : IRepository
    {
        public Repository()
        {
            Nhibernate = new Nhibernate();
        }
        public Nhibernate Nhibernate { get; set; }

        public void AddUser(User user)
        {
            using var transaction = Nhibernate.Session.BeginTransaction();
            Nhibernate.Session.Save(user);
            transaction.Commit();
        }

        public bool AuthenticateUser(string password, string passwordHash)
        {
            return (PasswordManager.HashPassword(password) == passwordHash);
        }

        public User GetUser(string userName)
        {
            var user = Nhibernate.Session.Query<User>().FirstOrDefault(u => u.UserName.ToLower().Equals(userName.ToLower()));
            return user;
        }

        
    }
}
