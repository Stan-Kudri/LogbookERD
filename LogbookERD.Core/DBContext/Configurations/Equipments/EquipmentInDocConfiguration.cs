using LogbookERD.Core.Models.Equipments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogbookERD.Core.DBContext.Configurations.Equipments
{
    public sealed class EquipmentInDocConfiguration : BaseEntityConfiguration<EquipmentInDocumentation>
    {
        protected override void ConfigureModel(EntityTypeBuilder<EquipmentInDocumentation> builder)
        {
            builder.ToTable("equipment");
            builder.Property(e => e.ExecutRepairDocId).IsRequired().HasColumnName("erdId");
        }
    }
}
