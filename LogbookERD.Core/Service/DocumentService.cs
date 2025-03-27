using LogbookERD.Core.DBContext;
using LogbookERD.Core.Models;
using LogbookERD.Core.Models.ItemRepository;
using LogbookERD.Core.Repository;
using LogbookERD.Core.Repository.Equpment;

namespace LogbookERD.Core.Service
{
    public class DocumentService
    {
        private readonly AppDBContext _appDBContext;

        private readonly DocumentRepository _documentRepository;

        private readonly EquipmentKKSRepository _equipmentKKSRepository;
        private readonly EquipmentNameRepository _equipmentNameRepository;
        private readonly EquipmentInDocRepository _equipmentInDocRepository;

        private readonly ExecutRepairDocRepository _executRepairDocRepository;
        private readonly PerfomerRepository _perfomerRepository;

        private ExecutRepairDocumentation _executRepairDocumentation;

        public DocumentService(DocumentRepository documentRepository,
                               EquipmentKKSRepository equipmentKKSRepository,
                               EquipmentNameRepository equipmentNameRepository,
                               EquipmentInDocRepository equipmentInDocRepository,
                               ExecutRepairDocRepository executRepairDocRepository,
                               PerfomerRepository perfomerRepository,
                               AppDBContext appDBContext)
        {
            _documentRepository = documentRepository;
            _equipmentKKSRepository = equipmentKKSRepository;
            _equipmentNameRepository = equipmentNameRepository;
            _equipmentInDocRepository = equipmentInDocRepository;
            _executRepairDocRepository = executRepairDocRepository;
            _perfomerRepository = perfomerRepository;
            _appDBContext = appDBContext;
        }

        public void InstallationERD(ExecutRepairDocumentation ERD) => _executRepairDocumentation = ERD;

        public void Add(DocumentModel document)
        {
            if (document == null)
            {
                throw new ArgumentNullException("Incorrect data.", nameof(document));
            }

            var executeRepDoc = _appDBContext.ExecutRepairDocumentations.FirstOrDefault(e => e == _executRepairDocumentation)
                                                                        ?? throw new ArgumentException("Execute repair documentation is not found.");

            _perfomerRepository.Add(document.Perfomer);
            var perfomerId = _appDBContext.Perfomer.FirstOrDefault(e => e == document.Perfomer)?.Id;

            foreach (var type in document.Types)
            {
                var lastItemRegistration = _appDBContext.Documents.FirstOrDefault(e => e.TypeDocumentation == type
                                                                                        && e.DateRegistration == document.DateRegistration
                                                                                        && e.OrdinalNumber != 0);
                var orderNumber = lastItemRegistration != null ? lastItemRegistration.OrdinalNumber + 1 : 1;
                document.ExecutRepairDocId = _executRepairDocumentation.Id;
                var equipmentInDocId = _appDBContext.EquipmentInDocumentations.FirstOrDefault(e => e.ExecutRepairDocId == _executRepairDocumentation.Id)
                                                                              ?? throw new InvalidOperationException("No identifier found for ERD.");
                document.EquipmentInDocId = equipmentInDocId.Id;
                document.ExecutRepairDocId = executeRepDoc.Id;
                _documentRepository.Add(document.GetDocument(type, orderNumber));
            }
        }
    }
}
