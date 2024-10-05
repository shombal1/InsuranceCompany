using MediatR;
using Microsoft.Extensions.Logging;

namespace InsuranceCompany.Domain.Monitoring;

public class MonitoringPipelineBehavior<TRequest, TResponse>(
    ILogger<MonitoringPipelineBehavior<TRequest, TResponse>> logger):IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            var result = await next.Invoke();
            return result;
        }
        catch (Exception exception)
        {
            logger.LogError(exception,"Unhandled error caught while handling command {Command}",request);            
            throw;
        }
    }
}