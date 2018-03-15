using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCollection.Service.Context
{
    public class ContextConfiguration
    {
        internal sealed class PrimaryContextConfiguration : DbMigrationsConfiguration<PrimaryContext>
        {
            public PrimaryContextConfiguration()
            {
                this.AutomaticMigrationsEnabled = false;
            }
               
        }

        internal sealed class ConfigContextConfiguration : DbMigrationsConfiguration<PrimaryContext>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ConfigContextConfiguration"/> class
            /// </summary>
            public ConfigContextConfiguration()
            {
                this.AutomaticMigrationsEnabled = false;
            }
        }
    }
}
