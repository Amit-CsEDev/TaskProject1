using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.DataAccess;
using TaskProoject.DataAccess.Models;

namespace TaskProject.DataAccess
{
    public class TPContext : DbContext, IDisposable
    {
        public TPContext() : base("TaskProjectEntities")
        {

        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Membership> Memberships { get; set; }

    }
}
