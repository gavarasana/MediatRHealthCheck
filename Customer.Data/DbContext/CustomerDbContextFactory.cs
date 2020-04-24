using Microsoft.EntityFrameworkCore;

namespace Customer.Data.DbContext
{
    public class CustomerDbContextFactory : DesignTimeDbContextFactory<CustomerDbContext>
    {
        protected override CustomerDbContext CreateNewInstance(DbContextOptions<CustomerDbContext> options)
        {
            return new CustomerDbContext(options);
        }
    }
}