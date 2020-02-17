using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reports.Core.Models;

namespace Reports.Data.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            //builder
            //    .HasKey(m => m.Id);

            //builder
            //    .Property(m => m.Id)
            //    .UseIdentityColumn();

            //builder
            //    .Property(m => m.Name)
            //    .IsRequired()
            //    .HasMaxLength(50);

            //builder
            //    .HasOne(m => m.)
            //    .WithMany(a => a.)
            //    .HasForeignKey(m => m.);

            //builder
            //    .ToTable("Cities");
        }
    }
}
