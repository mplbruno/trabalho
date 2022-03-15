using Apicursos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apicursos.Data
{
    public class CursoContext : DbContext
    {
        public CursoContext(DbContextOptions<CursoContext> options) : base(options)
        {

        }

        public DbSet<Courses> Courser {get; set;}
        public DbSet<Users>Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Courses>(e =>
            {
                e.ToTable("Courses");
                e.HasKey(p => p.Id);
                e.Property(p => p.Title).HasColumnType("varchar(40)").IsRequired();

            });
            modelBuilder.Entity<Users>(e =>
            {
                e.ToTable("Users");
                e.HasKey(p => p.Id);
                e.Property(p => p.Name).HasColumnType("varchar(40)").IsRequired();

            });

        }
    }
}
