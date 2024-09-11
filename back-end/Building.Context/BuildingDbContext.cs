using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Building.Models;
using Building.Models.Models;

namespace Building.Context.Context
{
    public class BuildingDbContext : IdentityDbContext<IdentityUser>
    {
        public BuildingDbContext(DbContextOptions<BuildingDbContext> options) : base(options) { }
        public virtual DbSet<Buildings> Buildings { get; set; }
       
    }
}
