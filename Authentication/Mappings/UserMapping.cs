using Authentication.Models;

namespace Authentication.Mappings
{
    public class UserMapping : BaseEntityMapping<User>
    {
        public UserMapping()
        {
            Table("Users");
            Map(x => x.UserName).Not.Nullable();
            Map(x => x.Password).Not.Nullable();
            Map(x => x.Email).Not.Nullable();
        }
    }
}
