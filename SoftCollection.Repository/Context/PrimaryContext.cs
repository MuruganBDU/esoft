using SoftCollection.Data.Model.Master;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCollection.Service.Context
{
    public class PrimaryContext: DbContext
    {
        public PrimaryContext() : base("ConnectionString")
        {
            var Connectionstring = GetConnectionString();
            base.Database.Connection.ConnectionString = Connectionstring;
            Database.SetInitializer<PrimaryContext>(null);
        }
        public DbSet<UserMaster> userMaster { get; set; }

        private string GetConnectionString()
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                return connectionString;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public override int SaveChanges()
        {
            var changeset = ChangeTracker.Entries();
            if(changeset != null)
            {
                foreach(var entry in changeset.Where(p => p.State == EntityState.Added || p.State == EntityState.Modified))
                {
                    if(entry.State == EntityState.Added)
                    {
                        //set property if common need
                    }
                    else
                    {
                        //set property if common need
                    }
                }
            }
            return base.SaveChanges();
        }

        private static void setPropertyValue(object obj, string property, object val)
        {
            var pro = obj.GetType().GetProperty(property, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            if (pro != null && pro.CanWrite)
                pro.SetValue(obj, val, null);
        }

        private static void getPropertyValue(object obj, string property)
        {
            var pro = obj.GetType().GetProperty(property, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            pro.GetValue(obj);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
