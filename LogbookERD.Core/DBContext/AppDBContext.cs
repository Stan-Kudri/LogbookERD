using LogbookERD.Core.DBContext.Configurations.Equipments;
using LogbookERD.Core.Models.ItemRepository;
using LogbookERD.Core.Models.ItemRepository.Equipments;
using Microsoft.EntityFrameworkCore;

namespace LogbookERD.Core.DBContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Document> Documents { get; set; }

        public DbSet<EquipmentKKS> EquipmentKKS { get; set; }

        public DbSet<EquipmentName> EquipmentNames { get; set; }

        public DbSet<EquipmentInDocumentation> EquipmentInDocumentations { get; set; }

        public DbSet<Perfomer> Perfomer { get; set; }

        public DbSet<ExecutRepairDocumentation> ExecutRepairDocumentations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(typeof(EquipmentKKSConfiguration).Assembly);
    }
}
