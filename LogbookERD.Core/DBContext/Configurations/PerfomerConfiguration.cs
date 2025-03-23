using LogbookERD.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogbookERD.Core.DBContext.Configurations
{
    public class PerfomerConfiguration : BaseEntityConfiguration<Perfomer>
    {
        protected override void ConfigureModel(EntityTypeBuilder<Perfomer> builder)
        {
            builder.ToTable("perfomer");
            builder.Property(e => e.Perfomers).HasColumnName("perfobers").IsRequired();
        }
    }
}
