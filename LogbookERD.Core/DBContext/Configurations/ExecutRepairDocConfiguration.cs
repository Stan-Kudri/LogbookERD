using LogbookERD.Core.Models.ItemRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogbookERD.Core.DBContext.Configurations
{
    public sealed class ExecutRepairDocConfiguration : BaseEntityConfiguration<ExecutRepairDocumentation>
    {
        protected override void ConfigureModel(EntityTypeBuilder<ExecutRepairDocumentation> builder)
        {
            builder.ToTable("ERD");
            builder.HasMany(e => e.Documents).WithOne(e => e.ERD).HasForeignKey(e => e.ExecutRepairDocId);
        }
    }
}
