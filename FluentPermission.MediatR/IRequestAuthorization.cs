using System;
using FluentPermission.Resources;
using FluentPermission.Rules;
using MediatR;

namespace FluentPermission.MediatR;

public interface IRequestAuthorization<T> where T : IBaseRequest
{
    AuthorizationRules<T> AuthorizationRules { get; }
    
    void RequirePermission(Permission permission);
    void RequireResourcePermission(Permission permission, Func<T, IPermissionResource> resourceFactory);
    void RequireFeatureFlag(string featureName);
}