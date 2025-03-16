using LogbookERD.Core.Data.Enum;
using LogbookERD.Core.Data.Identificator;

namespace LogbookERD.Core.Models.Documents
{
    public class CompletedWorkReport : BaseNumberGenerator
    {
        public CompletedWorkReport() : base(TypeDocumentation.CompletedWorkReport)
        {
        }
    }
}
