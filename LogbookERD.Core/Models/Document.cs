using LogbookERD.Core.Data.Enum;
using LogbookERD.Core.Models.Equipments;

namespace LogbookERD.Core.Models
{
    public class Document : Entity
    {
        //Тип исполнительной документации
        private readonly TypeDocumentation _documentation;

        public Document() => _documentation = TypeDocumentation.Unknown;

        public Document(TypeDocumentation documentation) => _documentation = documentation;

        //Дата ремонта
        public required DateTime RepairComplitionDate { get; set; }

        //Цех владелец оборудования
        public required Division Division { get; set; }

        //Дата регистрации
        public DateTime DateRegistration { get; set; } = DateTime.Now;

        //К какому типу объекта относиться оборудование
        public required RepairFacility RepairFacility { get; set; }

        //Примечание
        public string Note { get; set; } = string.Empty;

        //Порядковый номер документа
        public int OrdinalNumber { get; set; }

        //Регистрационный номер
        public string RegisterNumber { get; set; }

        //Изменение года регистрации документа
        public int? ChangeYearRepair { get; set; } = null;

        //Идентификатор исполнителей работ
        public Guid PerfomerId { get; set; }

        //Исполнители работ
        public Perfomer Perfomer { get; set; }

        //Идентификатор оборудования для документа
        public Guid EquipmentInDocId { get; set; }

        public EquipmentInDocumentation Equipment { get; set; }

        //Идентификатор принадлежности к комплекту ИРД
        public Guid ExecutRepairDocId { get; set; }

        public ExecutRepairDocumentation ERD { get; set; }

        public override string ToString()
            => $"{OrdinalNumber}/{Division.Value}{_documentation.Name}({RepairFacility.Value})-{YearRegistration}";

        private int YearRegistration => ChangeYearRepair == null ? RepairComplitionDate.Year : (int)ChangeYearRepair;
    }
}
