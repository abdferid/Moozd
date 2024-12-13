using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Concrete.EntityFramework
{
    public class MoozdDbContext : IdentityDbContext<User, Role, string>
    {
        public MoozdDbContext() { }

        public MoozdDbContext(DbContextOptions<MoozdDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // You may want to move this connection string to your appsettings.json for better configuration management.
            optionsBuilder.UseSqlServer("server=.;database=MoozdDB;integrated security=true;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Apply entity configurations from this assembly
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder); // Make sure Identity configurations are applied first
        }

        public DbSet<Motto> Mottos { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<ServiceHeader> ServiceHeaders { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServicesText> ServicesTexts { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }
    }
}
