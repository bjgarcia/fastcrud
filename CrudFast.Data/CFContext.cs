using CrudFast.Data.Domain;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CrudFast.Data
{
    public class CFContext : DbContext
    {
        public DbSet<ZipCode> ZipCodeSet { get; set; }

        public static string ConnectionStringName
        {
            get
            {
                string connectionString = "DefaultConnection";

                if (ConfigurationManager.AppSettings["ConnectionStringName"] != null)
                    connectionString = ConfigurationManager.AppSettings["ConnectionStringName"].ToString();
                return connectionString;
            }
        }

        public CFContext() : base(CFContext.ConnectionStringName) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // context configuartion and convention
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.HasDefaultSchema("qdicc");
        }
    }
}
