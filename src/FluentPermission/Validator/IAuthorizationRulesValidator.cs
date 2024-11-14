using FluentPermission.Abstractions;
using FluentPermission.Rules;

namespace FluentPermission.Validator;

public interface IAuthorizationRulesValidator
{
    Task ValidateAndThrowAsync<T>(AuthorizationRules<T> authorizationRules, IPermissionContext context, T request, CancellationToken cancellationToken = default);
}