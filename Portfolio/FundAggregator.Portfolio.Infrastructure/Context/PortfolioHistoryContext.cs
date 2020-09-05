using FundAggregator.Portfolio.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace FundAggregator.Portfolio.Infrastructure.Context
{
    public class PortfolioHistoryContext : DbContext
    {
        public PortfolioHistoryContext(DbContextOptions<PortfolioHistoryContext> options): base(options)
        { }

        public DbSet<Event> Events { get; set; }
    }
}
