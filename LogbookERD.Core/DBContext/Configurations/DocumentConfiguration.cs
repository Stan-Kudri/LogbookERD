using LogbookERD.Core.Extension;
using LogbookERD.Core.Models.ItemRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogbookERD.Core.DBContext.Configurations
{
    public sealed class DocumentConfiguration : BaseEntityConfiguration<Document>
    {
        protected override void ConfigureModel(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable("document");
            builder.Property(e => e.RepairComplitionDate).IsRequired().HasColumnName("repairComplitionDate");
            builder.Property(e => e.DateRegistration).IsRequired()
                                                     .HasColumnType("DATETIME")
                                                     .HasColumnName("DateRegistration")
                                                     .HasDefaultValue(DateTime.Now);
            builder.Property(e => e.TypeDocumentation).IsRequired().HasColumnName("Type").SmartEnumConversion();
            builder.Property(e => e.Division).IsRequired().HasColumnName("division").SmartEnumConversion();
            builder.Property(e => e.RepairFacility).IsRequired().HasColumnName("repairFacility").SmartEnumConversion();
            builder.Property(e => e.Note).HasColumnName("note");
            builder.Property(e => e.ChangeYearRepair).HasColumnName("changeRepairYearDocument").HasColumnType("DATETIME");
            builder.Property(e => e.EquipmentInDocId).IsRequired().HasColumnName("idEquipment");
            builder.Property(e => e.ExecutRepairDocId).IsRequired().HasColumnName("idExecutRepairDoc");
            builder.Property(e => e.OrdinalNumber).IsRequired().HasColumnName("orderNumber").HasColumnType("INTEGER");
            builder.Property(e => e.RegisterNumber).IsRequired().HasColumnName("registerNumber");
            builder.HasOne(e => e.Perfomer).WithMany(e => e.Documents).HasForeignKey(e => e.PerfomerId);
            builder.HasOne(e => e.ERD).WithMany(e => e.Documents).HasForeignKey(e => e.ExecutRepairDocId);
            builder.HasOne(e => e.Equipment).WithMany(e => e.Document).HasForeignKey(e => e.EquipmentInDocId);
        }
    }
}
