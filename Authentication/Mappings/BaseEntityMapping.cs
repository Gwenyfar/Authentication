using Authentication.Models;
using FluentNHibernate.Mapping;

namespace Authentication.Mappings
{
    public class BaseEntityMapping<T> : ClassMap<T> where T : BaseEntity
    {
        public BaseEntityMapping()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
        }
    }
}
