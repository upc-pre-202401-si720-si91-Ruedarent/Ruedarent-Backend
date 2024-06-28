

using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Commands;
using ACME.LearningCenter_Platform.VehiclesInformation.Interfaces.Rest.Resources;

namespace ACME.LearningCenter_Platform.VehiclesInformation.Interfaces.Rest.Transform;

public static class CreateCategoryCommandFromResourceAssembler
{
    public static CreateCategoryCommand ToCommandFromResource(CreateCategoryResource resource)
    {
        return new CreateCategoryCommand(resource.Name);
    }
}