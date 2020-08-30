using FundAggregator.Portfolio.Contracts.Commands;
using FundAggregator.Portfolio.Contracts.Interfaces;
using NServiceBus;
using System.Threading.Tasks;

namespace FundAggregator.Portfolio.Saga
{
    public class PortfolioPolicy : Saga<PortfolioPolicyData>, IAmStartedByMessages<CreatePortfolio>, IHandleMessages<UpdatePortfolio>
    {
        private IEventsFactory _eventsFactory;

        public PortfolioPolicy(IEventsFactory eventsFactory) {
            _eventsFactory = eventsFactory;
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<PortfolioPolicyData> mapper)
        {
            mapper.ConfigureMapping<CreatePortfolio>(command => command.PortfolioId).ToSaga(saga => saga.PortfolioId);
            mapper.ConfigureMapping<UpdatePortfolio>(command => command.PortfolioId).ToSaga(saga => saga.PortfolioId);
        }

        public Task Handle(CreatePortfolio command, IMessageHandlerContext context)
        {
            Data.PortfolioName = command.Name;
            var createdPortfolioEvent = _eventsFactory.CreatedCreatedPortfolioEvent(command.PortfolioId);
            return context.Publish(createdPortfolioEvent);
        }

        public Task Handle(UpdatePortfolio command, IMessageHandlerContext context)
        {
            Data.Investments = command.NewInvestmenets;
            var updatedPortfolioEvent = _eventsFactory.CreatedCreatedPortfolioEvent(command.PortfolioId);
            return context.Publish(updatedPortfolioEvent);
        }
    }
}
