using Infraestructure.Entity.Model;
using Infraestructure.Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Core.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<AutorEntity> AutoresEntity { get; set; }
        public DbSet<BookEntity> BookEntity { get; set; }
        public DbSet<EditorialEntity> EditorialEntity { get; set; }


        public DbSet<PermissionEntity> PermissionEntity { get; set; }
        public DbSet<RolEntity> RolEntity { get; set; }
        public DbSet<RolPermissionEntity> RolPermissionEntity { get; set; }
        public DbSet<TypePermissionEntity> TypePermissionEntity { get; set; }
        public DbSet<UserEntity> UserEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                      .HasIndex(b => b.UserName)
                      .IsUnique();
            
            modelBuilder.Entity<TypePermissionEntity>().Property(t => t.Id).ValueGeneratedNever();
            modelBuilder.Entity<RolEntity>().Property(t => t.Id).ValueGeneratedNever();
            modelBuilder.Entity<PermissionEntity>().Property(t => t.Id).ValueGeneratedNever();
        }
    }
}
