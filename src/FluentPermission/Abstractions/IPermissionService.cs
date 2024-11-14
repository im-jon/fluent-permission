namespace FluentPermission.Abstractions;

public interface IPermissionService
{
    bool IsPermitted(IPermissionContext context, Permission permission);
}