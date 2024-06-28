
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Entities;

namespace ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Aggregates;

public partial class Vehicle
{
    public Vehicle(string vehicleName, string description, int categoryId) : this()
    {
        VehicleName = vehicleName;
        Description = description;
        CategoryId = categoryId;
    }

    public int Id { get; }

    public string VehicleName { get; private set; }

    public string Description { get; private set; }

    public int CategoryId { get; private set; }

    public Category Category { get; internal set; }
}