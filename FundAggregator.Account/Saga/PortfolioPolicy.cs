using FundAggregator.Portfolio.Contracts.Commands;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundAggregator.Portfolio.Saga
{
    public class PortfolioPolicy : Saga<PortfolioPolicyData>, IAmStartedByMessages<CreatePortfolio>, IHandleMessages<UpdatePortfolio>
    {
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<PortfolioPolicyData> mapper)
        {
            mapper.ConfigureMapping<CreatePortfolio>(command => command.PortfolioId).ToSaga(saga => saga.PortfolioId);
            mapper.ConfigureMapping<UpdatePortfolio>(command => command.PortfolioId).ToSaga(saga => saga.PortfolioId);
        }

        public Task Handle(CreatePortfolio message, IMessageHandlerContext context)
        {
            throw new NotImplementedException();
        }

        public Task Handle(UpdatePortfolio message, IMessageHandlerContext context)
        {
            throw new NotImplementedException();
        }
    }
}
