using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchool.Domain.Entities;

namespace UpSchool.Persistence.EntityFramework.Configurations
{
    //veritabanı conf yapmak için 
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
          // id
          builder.HasKey(x => x.Id); // id keyi
            //title
            builder.Property(x=>x.Title).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(150);

            //username
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.UserName).HasMaxLength(100);

            //password
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.UserName).HasMaxLength(100);

            //url
            builder.Property(x => x.Url).IsRequired(false);
            builder.Property(x => x.Url).HasMaxLength(100);

          //is favourite
          builder.Property(x=>x.IsFavourite).IsRequired();
            //created on
            builder.Property(x => x.CreatedOn).IsRequired();

            //last modified on
            builder.Property(x => x.LastModifiedOn).IsRequired(false);

            builder.ToTable("Accounts");

        }
    }
}
