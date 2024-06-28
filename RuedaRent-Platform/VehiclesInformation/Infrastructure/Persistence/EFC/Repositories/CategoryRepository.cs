
using ACME.LearningCenter_Platform.Shared.Infraestructure.Persistence.EFC.Repositories;
using ACME.LearningCenter_Platform.Shared.Interfaces.ASP.Configuration;
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Entities;
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Repositories;

namespace ACME.LearningCenter_Platform.VehiclesInformation.Infrastructure.Persistence.EFC.Repositories;

public class CategoryRepository(AppDbContext context) : BaseRepository<Category>(context), ICategoryRepository;