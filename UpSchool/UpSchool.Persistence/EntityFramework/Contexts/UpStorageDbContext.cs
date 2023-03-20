using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchool.Domain.Entities;
using UpSchool.Persistence.EntityFramework.Configurations;

namespace UpSchool.Persistence.EntityFramework.Contexts
{
    public class UpStorageDbContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 

            //db tarafında modelleri oluştururken çalışır

            modelBuilder.ApplyConfiguration(new AccountConfiguration());   // oluşturduğumuz conf db ye yansıt 
            base.OnModelCreating(modelBuilder);
        }
        public UpStorageDbContext(DbContextOptions<UpStorageDbContext> options):base(options)
        {
            
        }
    }
}
