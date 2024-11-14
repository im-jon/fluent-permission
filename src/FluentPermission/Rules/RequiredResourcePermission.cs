using FluentPermission.Resources;

namespace FluentPermission.Rules;

public record RequiredResourcePermission<T>(Permission Permission, Func<T, IPermissionResource> ResourceFactory);