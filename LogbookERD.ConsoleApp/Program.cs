using LogbookERD.Core.Data.Enum;
using LogbookERD.Core.DBContext;
using LogbookERD.Core.Models;
using LogbookERD.Core.Models.ItemRepository;
using LogbookERD.Core.Repository;
using LogbookERD.Core.Repository.Equpment;
using LogbookERD.Core.Service;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = AppServiceDI();

using var contain = serviceCollection.BuildServiceProvider(new ServiceProviderOptions
{
    ValidateOnBuild = true,
    ValidateScopes = true,
});

using var scope = contain.CreateScope();

var service = scope.ServiceProvider.GetRequiredService<ExecuteRepairDocService>();

var equipment = new EquipmentModel("Арматура КСА", new List<string> { "10KAA12AA515", "10KAA12AA516" });
var documents = new DocumentModel(new List<TypeDocumentation>() { TypeDocumentation.EquipmentClosureProtocol, TypeDocumentation.RepairCompletionAct, TypeDocumentation.TechnicalConditionAct },
                                  new DateTime(2020, 5, 6), Division.ReactorShop, RepairFacility.EBFirst, new Perfomer() { Perfomers = { PerformerWork.BAS, } });

service.Add(equipment, documents);

static IServiceCollection AppServiceDI()
            => new ServiceCollection().AddSingleton<DbContextFactory>()
                                      .AddScoped(e => e.GetRequiredService<DbContextFactory>().Create())
                                      .AddScoped<EquipmentInDocRepository>()
                                      .AddScoped<EquipmentKKSRepository>()
                                      .AddScoped<EquipmentNameRepository>()
                                      .AddScoped<ExecutRepairDocRepository>()
                                      .AddScoped<PerfomerRepository>()
                                      .AddScoped<DocumentRepository>()
                                      .AddScoped<DocumentService>()
                                      .AddScoped<EquipmentService>()
                                      .AddScoped<ExecuteRepairDocService>();
