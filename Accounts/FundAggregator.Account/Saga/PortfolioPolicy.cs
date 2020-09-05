using FundAggregator.Portfolio.Contracts.Commands;
using FundAggregator.Portfolio.Contracts.Interfaces;
using Microsoft.Extensions.Logging;
using NServiceBus;
using System.Threading.Tasks;

namespace FundAggregator.Portfolio.Service.Saga
{
    public class PortfolioPolicy : Saga<PortfolioPolicyData>, IAmStartedByMessages<CreatePortfolio>, IHandleMessages<UpdatePortfolio>
    {
        private IEventsFactory _eventsFactory;
        private ILogger<PortfolioPolicy> _logger;

        public PortfolioPolicy(ILogger<PortfolioPolicy> logger, IEventsFactory eventsFactory) {
            _eventsFactory = eventsFactory;
            _logger = logger;
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<PortfolioPolicyData> mapper)
        {
            mapper.ConfigureMapping<CreatePortfolio>(command => command.PortfolioId).ToSaga(saga => saga.PortfolioId);
            mapper.ConfigureMapping<UpdatePortfolio>(command => command.PortfolioId).ToSaga(saga => saga.PortfolioId);
        }

        public Task Handle(CreatePortfolio command, IMessageHandlerContext context)
        {
            _logger.LogInformation($"Processing {nameof(CreatePortfolio)} with PortfolioId: {command.PortfolioId}");
            Data.PortfolioName = command.Name;
            var createdPortfolioEvent = _eventsFactory.CreatedCreatedPortfolioEvent(command.PortfolioId);
            return context.Publish(createdPortfolioEvent);
        }

        public Task Handle(UpdatePortfolio command, IMessageHandlerContext context)
        {
            _logger.LogInformation($"Processing {nameof(UpdatePortfolio)} with PortfolioId: {command.PortfolioId}");
            Data.Investments = command.NewInvestmenets;
            var updatedPortfolioEvent = _eventsFactory.CreatedCreatedPortfolioEvent(command.PortfolioId);
            return context.Publish(updatedPortfolioEvent);
        }
    }
}
