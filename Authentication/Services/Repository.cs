using Authentication.Models;
using NHibernate;

namespace Authentication.Services
{
    public class Repository : IRepository
    {


        public ISessionFactory SessionFactory => Nhibernate.CreateSessionFactory();

        public void AddUser(User user)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Save(user);
                        transaction.Commit();
                    }
                        
                }
                
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public bool AuthenticateUser(string password, string passwordHash)
        {
            return (PasswordManager.HashPassword(password) == passwordHash);
        }

        public User GetUser(string userName)
        {
            using var session = SessionFactory.OpenSession();
            var user = session.Query<User>().FirstOrDefault(u => u.UserName.ToLower().Equals(userName.ToLower()));
            return user;
        }

        
    }
}
