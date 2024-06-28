using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using RuedarentApi.Orders.Domain.Model.Aggregates;
using RuedarentApi.Plans.Domain.Model.Aggregates;
using RuedarentApi.Shared.Infraestructure.Persistences.EFC.Configuration.Extensions;
using RuedarentApi.UserProfile.Domain.Model.Aggregates;
using RuedarentApi.Vehicle.Domain.Model.Aggregates;

namespace RuedarentApi.Shared.Infraestructure.Persistences.EFC.Configuration;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }
    
    public DbSet<Plan> Plans { get; set; }

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
        
        //order
        builder.Entity<Order>().ToTable("Orders");
        builder.Entity<Order>().HasKey(o => o.Id);
        builder.Entity<Order>().Property(o => o.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Order>().Property(o => o.OwnerName).IsRequired().HasMaxLength(30);
        builder.Entity<Order>().Property(o => o.Discount).HasDefaultValue(0);
        //builder.Entity<Order>().Property(o => o.Subtotal).IsRequired().HasDefaultValue(0);
        builder.Entity<Order>().Property(o => o.Total).IsRequired().HasComputedColumnSql("(`Subtotal` - `Discount`)");
        builder.UseSnakeCaseNamingConvention();
        
        //Plan
        builder.Entity<Plan>().ToTable("Plans");
        builder.Entity<Plan>().HasKey(p => p.PlanId);
        builder.Entity<Plan>().Property(p => p.PlanId).IsRequired();
        builder.Entity<Plan>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Plan>().Property(p => p.Description).IsRequired();
        builder.Entity<Plan>().Property(p => p.Price).IsRequired();
        builder.Entity<Plan>().HasData(
            new Plan(1, "Plan Gratuito", "S/. 0 por 1 mes", 0),
            new Plan(2, "Plan Standard", "S/. 10 por 1 mes", 10),
            new Plan(3, "Plan Entusiasta", "S/. 21 por 1 mes", 21)
        );
        
        builder.Entity<Plan>().HasMany(p => p.Orders)
            .WithOne(o => o.Plan)
            .HasForeignKey(o => o.PlanId)
            .HasPrincipalKey(o => o.PlanId)
            .HasConstraintName("FK_Order_Plan");

        builder.UseSnakeCaseNamingConvention();
    }
}