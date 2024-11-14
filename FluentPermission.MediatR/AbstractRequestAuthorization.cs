using System;
using FluentPermission.Resources;
using FluentPermission.Rules;
using MediatR;

namespace FluentPermission.MediatR;

public class AbstractRequestAuthorization<T> : IRequestAuthorization<T> where T : IBaseRequest
{
    public AuthorizationRules<T> AuthorizationRules { get; } = new();
    
    public void RequirePermission(Permission permission)
    {
        this.AuthorizationRules.RequiredPermissions.Add(new RequiredPermission(permission));
    }

    public void RequireResourcePermission(Permission permission, Func<T, IPermissionResource> resourceFactory)
    {
        this.AuthorizationRules.RequiredResourcePermissions.Add(new RequiredResourcePermission<T>(permission, resourceFactory));
    }
    
    public void RequireFeatureFlag(string featureName)
    {
        this.AuthorizationRules.RequiredFeatureFlags.Add(new RequiredFeatureFlag(featureName));
    }
}