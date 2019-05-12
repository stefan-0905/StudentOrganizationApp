using StudentOrganizationLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentOrganizationApp
{
    public class StOrgDbContext : DbContext
    {
        public DbSet<Announcement> Announcements { get; set; }
    }
}
