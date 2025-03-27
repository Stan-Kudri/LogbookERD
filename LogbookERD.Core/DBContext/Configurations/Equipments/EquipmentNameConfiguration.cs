using LogbookERD.Core.Models.ItemRepository.Equipments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogbookERD.Core.DBContext.Configurations.Equipments
{
    public sealed class EquipmentNameConfiguration : BaseEntityConfiguration<EquipmentName>
    {
        protected override void ConfigureModel(EntityTypeBuilder<EquipmentName> builder)
        {
            builder.ToTable("equipmentName");
            builder.Property(e => e.Name).IsRequired().HasMaxLength(128).HasColumnName("name");
        }
    }
}
