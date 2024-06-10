using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using RuedarentApi.Shared.Infraestructure.Persistences.EFC.Configuration.Extensions;
using RuedarentApi.UserProfile.Domain.Model.Aggregates;
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
        
        builder.Entity<VehicleSource>().ToTable("FavoriteSource");
        builder.Entity<VehicleSource>().HasKey(f => f.Id);
        builder.Entity<VehicleSource>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<VehicleSource>().Property(f => f.VehiclesApiKey).IsRequired();
        builder.Entity<VehicleSource>().Property(f => f.SourceId).IsRequired();
        builder.Entity<VehicleSource>().Property(f => f.VehicleName).IsRequired();
        builder.Entity<VehicleSource>().Property(f => f.VehicleType).IsRequired();
        builder.Entity<VehicleSource>().Property(f => f.VehicleUserId).IsRequired();
//falta agregar los de vehiculos, sus datos y sus relaciones
        builder.Entity<UserSource>().ToTable("UserSource");
        builder.Entity<UserSource>().HasKey(f => f.Id);
        builder.Entity<UserSource>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<UserSource>().Property(f => f.Name).IsRequired();
        builder.Entity<UserSource>().Property(f => f.Surname).IsRequired();
        builder.Entity<UserSource>().Property(f => f.Email).IsRequired();
        builder.Entity<UserSource>().Property(f => f.Password).IsRequired();
        builder.Entity<UserSource>().Property(f => f.Phone).IsRequired();
        builder.Entity<UserSource>().Property(f => f.Address).IsRequired();
        builder.Entity<UserSource>().Property(f => f.City).IsRequired();
        builder.Entity<UserSource>().Property(f => f.Country).IsRequired();
        builder.Entity<UserSource>().Property(f => f.UserId).IsRequired();
        builder.Entity<UserSource>().Property(f => f.Dni).IsRequired();
     
        

        builder.UseSnakeCaseNamingConvention();
    }
}