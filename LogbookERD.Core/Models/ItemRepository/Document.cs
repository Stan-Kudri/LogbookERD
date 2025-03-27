using LogbookERD.Core.Data.Enum;
using LogbookERD.Core.Models.ItemRepository.Equipments;

namespace LogbookERD.Core.Models.ItemRepository
{
    public class Document : Entity
    {
        public Document()
        {
        }

        public Document(TypeDocumentation type,
                        DateTime repairDateComplit,
                        Division division,
                        RepairFacility repairFacility,
                        Perfomer perfomerWork,
                        int ordinalNumber,
                        Guid perfomerId,
                        Guid equipmentInDocId,
                        Guid executRepairDocId,
                        string note = "")
        {
            TypeDocumentation = type;
            RepairComplitionDate = repairDateComplit;
            Division = division;
            RepairFacility = repairFacility;
            Perfomer = perfomerWork;
            Note = note;
            OrdinalNumber = ordinalNumber;
            PerfomerId = perfomerId;
            EquipmentInDocId = equipmentInDocId;
            ExecutRepairDocId = executRepairDocId;
            SetRegisterNumber();
        }

        //Тип исполнительной документации
        public TypeDocumentation TypeDocumentation { get; set; }

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

        public string SetRegisterNumber()
            => RegisterNumber = $"{OrdinalNumber}/{Division.Value}{TypeDocumentation.Name}({RepairFacility.Value})-{YearRegistration}";

        private int YearRegistration => ChangeYearRepair == null ? RepairComplitionDate.Year : (int)ChangeYearRepair;
    }
}
