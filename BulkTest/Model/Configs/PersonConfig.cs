using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulkTest.Model.Configs
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");

            builder.Property(m => m.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.Discriminator)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasDiscriminator<string>(nameof(Person.Discriminator))
                .HasValue<Student>(nameof(Student))
                .HasValue<Teacher>(nameof(Teacher));
        }
    }
}
