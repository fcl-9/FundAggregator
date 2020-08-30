using FundAggregator.Portfolio.Infrastructure.Model;
namespace FundAggregator.Portfolio.Infrastructure.Interfaces
{
    public interface IPortfolioHistoryRepository
    {
        void AddPortfolioHistory(Event evntToPersist);
    }
}
