using LogbookERD.Core.Data.Enum;
using LogbookERD.Core.Models.ItemRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LogbookERD.Core.DBContext.Configurations
{
    public class PerfomerConfiguration : BaseEntityConfiguration<Perfomer>
    {
        protected override void ConfigureModel(EntityTypeBuilder<Perfomer> builder)
        {
            builder.ToTable("perfomer");
            builder.Property(e => e.PerfomersWorks)
                .HasColumnName("perfomers")
                .IsRequired()
                .HasConversion(
                               e => string.Join(',', e),
                               e => e.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
            builder.HasMany(e => e.Documents).WithOne(e => e.Perfomer).HasForeignKey(e => e.PerfomerId);
        }
    }


    // Конвертер для SmartEnum
    public class UserPerfomerConverter : ValueConverter<PerformerWork, int>
    {
        public UserPerfomerConverter() : base(
            v => v.Value,
            v => PerformerWork.FromValue(v))
        {
        }
    }
}
