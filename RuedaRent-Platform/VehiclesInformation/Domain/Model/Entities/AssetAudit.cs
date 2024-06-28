using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Entities;

public partial class Asset : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}