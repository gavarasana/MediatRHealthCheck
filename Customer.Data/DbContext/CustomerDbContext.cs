using System.Threading;
using System.Threading.Tasks;
using Customer.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Customer.Data.DbContext
{
    public class CustomerDbContext :  Microsoft.EntityFrameworkCore.DbContext
    {
        
        public DbSet<Domain.Models.Customer> Customers { get; set; }
        
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyAllConfigurations<CustomerDbContext>();
        }

        public override int SaveChanges()
        {
            this.AddAuditInfo();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            this.AddAuditInfo();
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}