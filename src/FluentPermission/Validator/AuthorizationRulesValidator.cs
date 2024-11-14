using FluentPermission.Abstractions;
using FluentPermission.Exceptions;
using FluentPermission.Rules;

namespace FluentPermission.Validator;

public class AuthorizationRulesValidator(IPermissionService permissionService,
    IResourcePermissionService resourcePermissionService,
    IFeatureManager featureManager) : IAuthorizationRulesValidator
{
    public async Task ValidateAndThrowAsync<T>(AuthorizationRules<T> authorizationRules, IPermissionContext context, T request, CancellationToken cancellationToken = default)
    {
        foreach (var requiredPermission in authorizationRules.RequiredPermissions)
        {
            if (!permissionService.IsPermitted(context, requiredPermission.Permission))
            {
                throw new RequiredPermissionException(requiredPermission.Permission);
            }
        }
            
        foreach (var requiredResourcePermission in authorizationRules.RequiredResourcePermissions)
        {
            var resource = requiredResourcePermission.ResourceFactory(request);
            if (!await resourcePermissionService.IsPermittedOnResourceAsync(context, resource, requiredResourcePermission.Permission, cancellationToken))
            {
                throw new RequiredPermissionException(requiredResourcePermission.Permission);
            }
        }

        foreach (var requiredFeatureFlag in authorizationRules.RequiredFeatureFlags)
        {
            if (!await featureManager.IsEnabledAsync(requiredFeatureFlag.FeatureName))
            {
                throw new RequiredFeatureFlagException(requiredFeatureFlag.FeatureName);
            }
        }
    }
}