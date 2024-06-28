

using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Entities;
using ACME.LearningCenter_Platform.VehiclesInformation.Interfaces.Rest.Resources;

namespace ACME.LearningCenter_Platform.VehiclesInformation.Interfaces.Rest.Transform;

public static class CategoryResourceFromEntityAssembler
{
    public static CategoryResource ToResourceFromEntity(Category entity)
    {
        return new CategoryResource(entity.Id, entity.Name);
    }
}