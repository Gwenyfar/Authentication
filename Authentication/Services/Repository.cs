using Authentication.Models;

namespace Authentication.Services
{
    public class Repository
    {
        public Repository()
        {
            Nhibernate = new Nhibernate();
        }
        public Nhibernate Nhibernate { get; set; }
        
        public User GetUser(string userName)
        {
            var user = Nhibernate.Session.Query<User>().FirstOrDefault(u => u.UserName.ToLower().Equals(userName.ToLower()));
            return user;
        }
    }
}
