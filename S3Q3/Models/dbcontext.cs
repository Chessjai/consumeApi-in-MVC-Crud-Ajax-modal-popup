using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace S3Q3.Models
{
    public class dbcontext : DbContext

    {
        public dbcontext() : base("MyConnectionString")
        {
            Database.SetInitializer<dbcontext>(null);
        }
        public DbSet<studentmodel> models { get; set; }

    }
    
    }
