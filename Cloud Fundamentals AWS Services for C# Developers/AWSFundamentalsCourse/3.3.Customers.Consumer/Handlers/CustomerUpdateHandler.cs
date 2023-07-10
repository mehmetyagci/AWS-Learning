using Customers.Consumer.Messages;
using MediatR;

namespace Customers.Consumer.Handlers {
    public class CustomerUpdateHandler : IRequestHandler<CustomerUpdated> {

        private readonly ILogger<CustomerUpdateHandler> _logger;

        public CustomerUpdateHandler(ILogger<CustomerUpdateHandler> logger) {
            _logger = logger;
        }

        public Task<Unit> Handle(CustomerUpdated request, CancellationToken cancellationToken) {
            _logger.LogInformation(request.GitHubUsername);
            return Unit.Task;
        }
    }
}
