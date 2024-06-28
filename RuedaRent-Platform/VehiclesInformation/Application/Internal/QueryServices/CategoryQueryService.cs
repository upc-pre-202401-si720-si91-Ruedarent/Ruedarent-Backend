
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Entities;
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Queries;
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Repositories;
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Services;

namespace ACME.LearningCenter_Platform.VehiclesInformation.Application.Internal.QueryServices;

public class CategoryQueryService(ICategoryRepository categoryRepository) : ICategoryQueryServices
{
    public async Task<Category?> Handle(GetCategoryByIdQuery query)
    {
        return await categoryRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query)
    {
        return await categoryRepository.ListAsync();
    }
}