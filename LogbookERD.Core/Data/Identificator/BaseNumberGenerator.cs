using LogbookERD.Core.Data.Enum;
using LogbookERD.Core.Models;

namespace LogbookERD.Core.Data.Identificator
{
    public abstract class BaseNumberGenerator : Entity
    {
        //Тип исполнительной документации
        private readonly TypeDocumentation _documentation;

        protected BaseNumberGenerator(TypeDocumentation documentation)
            => _documentation = documentation;

        //Цех владелец оборудования
        public required Division Division { get; set; }

        //Исполнитель работ
        public required PerformerWork Performer { get; set; }

        //Дата ремонта
        public required DateTime DateRepair { get; set; }

        //Дата регистрации
        public DateTime DateRegistration { get; set; } = DateTime.Now;

        //К какому типу объекта относиться оборудование
        public required RepairFacility RepairFacility { get; set; }

        //Примечание
        public string Note { get; set; } = string.Empty;

        //Изменение года регистрации документа
        public int? ChangeYearRepair { get; set; } = null;

        //Порядковый номер документа
        public int OrdinalNumber { get; set; }

        public override string ToString()
            => $"{OrdinalNumber}/{Division.Value}{_documentation.Name}({RepairFacility.Value})-{YearRegistration}";

        private int YearRegistration => ChangeYearRepair == null ? DateRepair.Year : (int)ChangeYearRepair;
    }
}
