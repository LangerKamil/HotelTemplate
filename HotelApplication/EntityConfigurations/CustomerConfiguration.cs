using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelApplication.Models;


namespace HotelApplication.EntityConfigurations
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.IDNumber)
                .IsRequired()
                .HasColumnAnnotation("IDNumber",
                new IndexAnnotation(new[] {
                    new IndexAttribute("IDNumber") { IsUnique = true } }))
                    .HasMaxLength(35);
            Property(c => c.PhoneNumber)
                .HasMaxLength(16);

            Property(c => c.EmailAddress)
                .HasMaxLength(255);

        }
    }
}