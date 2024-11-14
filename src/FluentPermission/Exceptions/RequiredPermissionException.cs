namespace FluentPermission.Exceptions;

public class RequiredPermissionException(Permission permission)
    : Exception($"Permission {permission.Value} is required to access this resource.");