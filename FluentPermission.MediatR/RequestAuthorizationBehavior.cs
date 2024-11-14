using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentPermission.Abstractions;
using FluentPermission.Validator;
using MediatR;

namespace FluentPermission.MediatR;

public class RequestAuthorizationBehavior<TRequest, TResponse>(
    IEnumerable<IRequestAuthorization<TRequest>> permissions,
    IAuthorizationRulesValidator authorizationRulesValidator,
    IPermissionContext permissionContext) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (permissions.Any())
        {
            // For now, we will only have one permission configuration per request
            var authorizationRules = permissions.Single().AuthorizationRules;
            await authorizationRulesValidator.ValidateAndThrowAsync(authorizationRules, permissionContext, request, cancellationToken);
        }
        
        return await next();
    }
}