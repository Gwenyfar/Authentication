using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.Models
{
    public class BaseEntity
    {
     
        public virtual Guid Id { get; set; }
    }
}
