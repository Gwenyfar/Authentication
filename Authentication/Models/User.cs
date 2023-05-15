namespace Authentication.Models
{
    public class User : BaseEntity
    {
        public virtual string UserName { get; set; } 
        public virtual string Password { get; set; } 
        public virtual string Email { get; set; }
    }
}
