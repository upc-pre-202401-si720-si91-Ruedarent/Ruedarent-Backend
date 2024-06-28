
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Aggregates;

namespace ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Entities;

public class Category
{
    public Category()
    {
        Name = string.Empty;
    }

    public Category(string name)
    {
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Vehicle> Tutorials { get; }
}