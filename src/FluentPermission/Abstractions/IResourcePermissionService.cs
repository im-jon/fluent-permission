using FluentPermission.Resources;

namespace FluentPermission.Abstractions;

public interface IResourcePermissionService
{
    Task<bool> IsPermittedOnResourceAsync(IPermissionContext context, IPermissionResource permissionResource, Permission permission, CancellationToken cancellationToken);
}