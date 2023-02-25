using Infraestructure.Entity.Model;
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

        public DbSet<AutorBookEntity> AutorBookEntity { get; set; }
        public DbSet<AutoresEntity> AutoresEntity { get; set; }
        public DbSet<BookEntity> BookEntity { get; set; }
        public DbSet<EditorialEntity> EditorialEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
