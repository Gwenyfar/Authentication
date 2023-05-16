using Authentication.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using ISession = NHibernate.ISession;

namespace Authentication.Services
{
    public class Nhibernate
    {
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012.ConnectionString("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\iruoma.onyia\\Documents\\User.mdf;Integrated Security=True;Connect Timeout=30;")
            .ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
                .BuildSessionFactory();
        }

        
    }
}
