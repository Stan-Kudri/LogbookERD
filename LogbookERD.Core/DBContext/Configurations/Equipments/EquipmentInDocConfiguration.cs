using LogbookERD.Core.Models.ItemRepository.Equipments;
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

            /*
            builder.HasMany(e => e.KKS)
                   .WithOne() // или .WithOne(k => k.EquipmentInDocumentation) если есть навигационное свойство в EquipmentKKS
                   .HasForeignKey(e => e.Id); // предполагаемое имя FK в EquipmentKKS
            */

            builder.HasMany(e => e.Document)
                   .WithOne(e => e.Equipment) // или .WithOne(d => d.EquipmentInDocumentation) если есть навигационное свойство в Document
                   .HasForeignKey(e => e.EquipmentInDocId); // предполагаемое имя FK в Document

            builder.HasOne(e => e.ExecutRepairDocumentation)
                   .WithMany() // или .WithMany(erd => erd.EquipmentInDocumentations) если есть коллекция в ExecutRepairDocumentation
                   .HasForeignKey(e => e.ExecutRepairDocId);
        }
    }
}
