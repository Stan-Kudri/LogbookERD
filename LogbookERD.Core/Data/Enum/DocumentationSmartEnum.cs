using Ardalis.SmartEnum;
using System.Text.Json.Serialization;

namespace LogbookERD.Core.Data.Enum
{
    public class DocumentationSmartEnum : SmartEnum<DocumentationSmartEnum>
    {
        public static DocumentationSmartEnum Checlist = new DocumentationSmartEnum("", "Чек-лист к Исполнительной Ремонтной Документации", 0);
        public static DocumentationSmartEnum CCERW = new DocumentationSmartEnum("АВР", "Акт Выполненных Ремонтных Работ Оборудования", 1);
        public static DocumentationSmartEnum CCERW4 = new DocumentationSmartEnum("АВР4", "Акт Выполненных Ремонтных Работ Оборудования Четвертого Класса", 2);
        public static DocumentationSmartEnum LE = new DocumentationSmartEnum("ПО", "Перечень Оборудования К Акту О Выполненных Работах", 3);
        public static DocumentationSmartEnum LCW = new DocumentationSmartEnum("ВВР", "Ведомость Выполненных Работ", 4);
        public static DocumentationSmartEnum LAUM = new DocumentationSmartEnum("ВИМ", "Ведомость Фактически Используемых (Затраченых) Материалов", 5);
        public static DocumentationSmartEnum CED = new DocumentationSmartEnum("АДО", "Акт О Дефектах Оборудования", 6);
        public static DocumentationSmartEnum PECAR = new DocumentationSmartEnum("ПЗО", "Протокол Закрытия Оборудования После Ремонта", 7);
        public static DocumentationSmartEnum PEFCAR = new DocumentationSmartEnum("ППИ", "Протокол Проверки Исправности Оборудования После Ремонта", 8);
        public static DocumentationSmartEnum PEDT = new DocumentationSmartEnum("ПИО", "Протокол Испытания Оборудования На Плотность", 9);

        private DocumentationSmartEnum(string name, string abbreviationDecoding, int value)
             : base(name, value) => AbbreviationDecoding = abbreviationDecoding;

        [JsonPropertyName("AbbreviationDecoding")]
        public string AbbreviationDecoding { get; }
    }
}
