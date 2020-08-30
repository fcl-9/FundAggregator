using FundAggregator.Portfolio.Contracts.Events;
using FundAggregator.Portfolio.Infrastructure.Interfaces;
using FundAggregator.Portfolio.Infrastructure.Model;
using Microsoft.Extensions.Logging;
using NServiceBus;
using System;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace FundAggregator.Portfolio.Service.Handler
{
    // TODO: Move this to another service. That only cares about history. Services shall be atomic in what they do...
    public class PortfolioHistoryHandler : IHandleMessages<CreatedPortfolio>, IHandleMessages<UpdatedPortfolio>
    {
        private IPortfolioHistoryRepository _portfolioHistoryRepository;
        private ILogger<PortfolioHistoryHandler> _logger;

        public PortfolioHistoryHandler(ILogger<PortfolioHistoryHandler> logger, IPortfolioHistoryRepository portfolioHistoryRepository) {
            _portfolioHistoryRepository = portfolioHistoryRepository;
            _logger = logger;
        }

        public Task Handle(CreatedPortfolio evnt, IMessageHandlerContext context)
        {
            _logger.LogInformation($"Persisting {nameof(CreatedPortfolio)} for PortfolioId: {evnt.PortfolioId}");

            var eventToPersist = new Event()
            {
                EventId = Guid.NewGuid(),
                PortfolioId = evnt.PortfolioId,
                Payload = JsonSerializer.Serialize(evnt),
                CreateDate = evnt.CreatedDate
            };

            _portfolioHistoryRepository.AddPortfolioHistory(eventToPersist);
            return Task.CompletedTask;
        }

        public Task Handle(UpdatedPortfolio evnt, IMessageHandlerContext context)
        {
            _logger.LogInformation($"Persisting {nameof(UpdatedPortfolio)} for PortfolioId: {evnt.PortfolioId}");
            var eventToPersist = new Event()
            {
                EventId = Guid.NewGuid(),
                PortfolioId = evnt.PortfolioId,
                Payload = JsonSerializer.Serialize(evnt),
                CreateDate = evnt.CreatedDate
            }; 
            _portfolioHistoryRepository.AddPortfolioHistory(eventToPersist);
            return Task.CompletedTask;
        }
    }
}
