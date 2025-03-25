using LogbookERD.Core.Data.Enum;
using LogbookERD.Core.Models.ItemRepository;
using LogbookERD.Core.Models.ItemRepository.Equipments;

namespace LogbookERD.Core.Models
{
    public class DocumentModel
    {
        public DocumentModel(List<TypeDocumentation> types,
                             DateTime repairDateComplit,
                             Division division,
                             RepairFacility repairFacility,
                             Perfomer perfomerWork,
                             string note = "")
        {
            Types = types.Count > 0 ? types : throw new ArgumentException("Documents for registration are not selected.");
            DateRegistration = DateTime.Now;
            RepairComplitionDate = repairDateComplit < DateRegistration
                                    ? repairDateComplit
                                    : throw new ArgumentException("Incorrect repair complite date.", nameof(repairDateComplit));
            Division = division;
            RepairFacility = repairFacility;
            Perfomer = perfomerWork;
            Note = note;
        }

        //Типы документов
        public List<TypeDocumentation> Types { get; set; }

        //Дата ремонта
        public DateTime RepairComplitionDate { get; set; }

        //Цех владелец оборудования
        public Division Division { get; set; }

        //Дата регистрации
        public DateTime DateRegistration { get; set; } = DateTime.Now;

        //К какому типу объекта относиться оборудование
        public RepairFacility RepairFacility { get; set; }

        //Примечание
        public string Note { get; set; } = string.Empty;

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

        public Document GetDocument(TypeDocumentation type, int orderNumber)
            => new Document(type, RepairComplitionDate, Division, RepairFacility, Perfomer, orderNumber, Note);
    }
}
