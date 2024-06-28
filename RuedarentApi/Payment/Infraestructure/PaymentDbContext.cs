using Microsoft.EntityFrameworkCore;

namespace RuedarentApi.Payment.Infrastructure
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
        {
        }
        
        public DbSet<Domain.Model.Aggregates.Payment> Payments { get; set; }
    }
}