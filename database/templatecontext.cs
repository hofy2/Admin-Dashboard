 using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using template.dal.entity;
namespace template.dal.database
{
   public class templatecontext : DbContext
    {

        public templatecontext(DbContextOptions<templatecontext> opt) : base(opt)
        {

        }
        public DbSet<department> department { get; set; }
        public DbSet<employee> employee { get; set; }

        
    }
}
