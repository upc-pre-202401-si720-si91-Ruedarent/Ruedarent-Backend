
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Entities;
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Queries;

namespace ACME.LearningCenter_Platform.VehiclesInformation.Domain.Services;

public interface ICategoryQueryServices
{
    Task<Category?> Handle(GetCategoryByIdQuery query);

    Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query);
}