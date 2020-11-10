using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace webApp.DataAcessLayer
{
    public class RiteDBContext: DbContext
    {

        protected RiteDBContext() : base("RiteDbContext")
        {
        }
        protected RiteDBContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }
        public static RiteDBContext CreateContext()
        {
            return new RiteDBContext();
        }

    }
}