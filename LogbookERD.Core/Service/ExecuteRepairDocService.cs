using LogbookERD.Core.Models;
using LogbookERD.Core.Models.ItemRepository;
using LogbookERD.Core.Repository;

namespace LogbookERD.Core.Service
{
    public class ExecuteRepairDocService
    {
        private readonly ExecutRepairDocRepository _executeRpairDocRepository;

        private readonly EquipmentService _equipmentService;
        private readonly DocumentService _serviceDocument;

        public ExecuteRepairDocService(ExecutRepairDocRepository executRepairDocRepository,
                                       EquipmentService equipmentService,
                                       DocumentService serviceDocument)
        {
            _executeRpairDocRepository = executRepairDocRepository;
            _equipmentService = equipmentService;
            _serviceDocument = serviceDocument;
        }

        public void Add(EquipmentModel equpmentModel, DocumentModel documentModel)
        {
            var executeRepDoc = new ExecutRepairDocumentation();
            _executeRpairDocRepository.Add(executeRepDoc);

            _equipmentService.InstallationERD(executeRepDoc);
            _serviceDocument.InstallationERD(executeRepDoc);

            _equipmentService.Add(equpmentModel);
            _serviceDocument.Add(documentModel);
        }
    }
}
