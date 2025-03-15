using Ardalis.SmartEnum;
using System.Text.Json.Serialization;

namespace LogbookERD.Core.Data.Enum
{
    public class DocumentationSmartEnum : SmartEnum<DocumentationSmartEnum>
    {
        public static DocumentationSmartEnum Checlist = new("", "Чек-лист к Исполнительной Ремонтной Документации", 0);
        public static DocumentationSmartEnum CCERW = new("АВР", "Акт о выполненных  работах по ремонту оборудования", 1);
        public static DocumentationSmartEnum CCERW4 = new("АВР4", "Акт о выполненных  работах по ремонту оборудования (класс безопасности 4)", 2);
        public static DocumentationSmartEnum LE = new("ПО", "Перечень оборудования к акту о выполненных работах по ремонту оборудования", 3);
        public static DocumentationSmartEnum LCW = new("ВВР", "Ведомость выполненных работ", 4);
        public static DocumentationSmartEnum LAUM = new("ВИМ", "Ведомость фактически Затраченных (Используемых) материалов и запасных частей", 5);
        public static DocumentationSmartEnum CED = new("АДО", "Акт о дефектах оборудования (трубопроводов)", 6);
        public static DocumentationSmartEnum PECAR = new("ПЗО", "Протокол закрытия оборудования", 7);
        public static DocumentationSmartEnum PEFCAR = new("ППИ", "Протокол проверки исправности оборудования после ремонта", 8);
        public static DocumentationSmartEnum PEDT = new("ПИО", "Протокол испытания оборудования на плотность", 9);
        public static DocumentationSmartEnum POC = new("ПОК", "Протокол операционного контроля при ремонте оборудования", 10);
        public static DocumentationSmartEnum CUSMDR = new("АИМЗ", "Акт об использовании материалов заменителей при ремонте", 11);
        public static DocumentationSmartEnum CCEI = new("АОМ", "Акт окончания монтажа оборудования (трубопровода)", 12);
        public static DocumentationSmartEnum CTC = new("АТС", "Акт о техническом состоянии оборудования", 13);

        private DocumentationSmartEnum(string name, string abbreviationDecoding, int value)
             : base(name, value) => AbbreviationDecoding = abbreviationDecoding;

        [JsonPropertyName("AbbreviationDecoding")]
        public string AbbreviationDecoding { get; }
    }
}
