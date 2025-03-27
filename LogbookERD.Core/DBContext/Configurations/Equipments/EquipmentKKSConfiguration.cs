using LogbookERD.Core.Models.ItemRepository.Equipments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogbookERD.Core.DBContext.Configurations.Equipments
{
    public sealed class EquipmentKKSConfiguration : BaseEntityConfiguration<EquipmentKKS>
    {
        protected override void ConfigureModel(EntityTypeBuilder<EquipmentKKS> builder)
        {
            builder.ToTable("kks");
            builder.Property(e => e.KKS).HasMaxLength(16).IsRequired().HasColumnName("kks");
            builder.Property(e => e.EquipmentNameId).IsRequired().HasColumnName("equipmentNameId");
            builder.HasOne(e => e.EquipmentName).WithMany(e => e.EquipmentsKKS).HasForeignKey(e => e.EquipmentNameId);
            builder.HasMany(e => e.EquipmentInDocs).WithMany(e => e.KKS);
        }
    }
}
