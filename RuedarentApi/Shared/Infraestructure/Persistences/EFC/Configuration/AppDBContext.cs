using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using RuedarentApi.Shared.Infraestructure.Persistences.EFC.Configuration.Extensions;
using RuedarentApi.Vehicle.Domain.Model.Aggregates;

namespace RuedarentApi.Shared.Infraestructure.Persistences.EFC.Configuration;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<FavoriteSource>().ToTable("FavoriteSource");
        builder.Entity<FavoriteSource>().HasKey(f => f.Id);
        builder.Entity<FavoriteSource>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<FavoriteSource>().Property(f => f.VehiclesApiKey).IsRequired();
        builder.Entity<FavoriteSource>().Property(f => f.SourceId).IsRequired();
        builder.Entity<FavoriteSource>().Property(f => f.VehicleName).IsRequired();
        builder.Entity<FavoriteSource>().Property(f => f.VehicleType).IsRequired();
        builder.Entity<FavoriteSource>().Property(f => f.VehicleUserId).IsRequired();
//falta agregar los de vehiculos, sus datos y sus relaciones
        builder.UseSnakeCaseNamingConvention();
    }
}