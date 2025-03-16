using Ardalis.SmartEnum;
using System.Text.Json.Serialization;

namespace LogbookERD.Core.Data.Enum
{
    public class Division : SmartEnum<Division>
    {
        public static Division AutoTransShop = new("ATS", "АЦ", "Автотранспортный цех", 11);
        public static Division ReactorShop = new("RS", "РЦ", "Реакторный цех", 21);
        public static Division TurbineShop = new("TS", "ТЦ", "Турбинный цех", 22);
        public static Division ServiceSysShop = new("SSS", "ЦОС", "Цех обеспечивающих систем", 23);
        public static Division ChemicalShop = new("CS", "ХЦ", "Химический цех", 24);
        public static Division VentilationAndACShop = new("VACS", "ЦВиК", "Цех вентиляции и кондиционирования", 25);
        //public static DivisionSmartEnum СS = new DivisionSmartEnum("CS", "ЛПДТК", "Лаборатория", 26);                  
        public static Division PowerShop = new("PS", "ЭЦ", "Электрический цех", 27);
        //public static DivisionSmartEnum СS = new DivisionSmartEnum("CS", "ЦОРО", "Цех о", 30);
        public static Division NucSafeDept = new("NSD", "ОЯБ", "Отдел ядерной безопасности", 31);
        public static Division RadSafeWorks = new("RSW", "ЦРБ", "Цех радиационной безопасности", 33);
        public static Division CentralRepairShop = new("CRS", "ЦЦР", "Цех централизованного ремонта", 35);
        public static Division DeactShop = new("DS", "ЦД", "Цех дезактивации", 36);
        public static Division RepairPreparationDepartment = new("RPD", "ОППР", "Отдел подготовки и проведения ремонтов", 38);
        public static Division ExpModUnit = new("EMU", "ОУРМ", "Отдел учета опыта и модернизации", 54);

        private Division(string name, string nameRussion, string abbreviationDecoding, int value)
             : base(name, value)
        {
            AbbreviationDecoding = abbreviationDecoding;
            RusDivision = nameRussion;
        }

        [JsonPropertyName("AbbreviationDecoding")]
        public string AbbreviationDecoding { get; }

        [JsonPropertyName("DivisionRussianName")]
        public string RusDivision { get; }
    }
}
