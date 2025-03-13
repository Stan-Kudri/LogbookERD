using LogbookERD.Core.Data.Enum;

namespace LogbookERD.Core.Data.Identificator
{
    public abstract class BaseNumberGenerator
    {
        //Цех владелец оборудования
        public DivisionSmartEnum Division { get; set; }

        //Исполнитель работ
        public PerformerWork Performer { get; set; }

        //Тип исполнительной документации
        public DocumentationSmartEnum Documentation { get; set; }

        //Дата ремонта
        public DateTime DateRepair { get; set; }

        //Дата регистрации
        public DateTime DateRegistration { get; set; }

        //К какому типу объекта относиться оборудование
        public RepairFacility RepairFacility { get; set; }

        //Изменение года регистрации документа
        public int? ChangeYearRepair { get; set; } = null;

        //Идентификатор
        public Guid Id { get; set; }

        //Порядковый номер документа
        public int OrdinalNumber { get; set; }

        //Идентификатор ИРД
        public Guid RepairDocumentationID { get; set; }

        public override string ToString()
            => $"{OrdinalNumber}/{Division.Value}{Documentation.Name}({RepairFacility.Value})-{YearRegistration}";

        private int YearRegistration => ChangeYearRepair == null ? DateRepair.Year : (int)ChangeYearRepair;
    }
}
