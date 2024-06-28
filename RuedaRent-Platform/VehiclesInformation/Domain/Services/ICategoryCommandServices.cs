
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Commands;
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Entities;

namespace ACME.LearningCenter_Platform.VehiclesInformation.Domain.Services;

public interface ICategoryCommandServices
{
    public Task<Category?> Handle(CreateCategoryCommand command);
}