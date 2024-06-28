
using ACME.LearningCenter_Platform.Shared.Domain.Repositories;
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Aggregates;
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Commands;
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Repositories;
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Services;

namespace ACME.LearningCenter_Platform.VehiclesInformation.Application.Internal.CommandServices;

public class VehicleCommandService(
    IVehicleRepository vehicleRepository,
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork) : IVehicleCommandServices
{
    public async Task<Vehicle?> Handle(AddImageAssetToVehicleCommand command)
    {
        var tutorial = await vehicleRepository.FindByIdAsync(command.TutorialId);
        if (tutorial is null) throw new Exception("Tutorial not found");
        tutorial.AddImage(command.ImageUrl);
        await unitOfWork.CompleteAsync();
        return tutorial;
    }

    public async Task<Vehicle?> Handle(CreateVehicleCommand command)
    {
        var tutorial = new Vehicle(command.VehicleName, command.Description, command.CategoryId);
        await vehicleRepository.AddSync(tutorial);
        await unitOfWork.CompleteAsync();
        var category = await categoryRepository.FindByIdAsync(command.CategoryId);
        tutorial.Category = category;
        return tutorial;
    }
}