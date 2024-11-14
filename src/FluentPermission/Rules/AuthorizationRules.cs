namespace FluentPermission.Rules;

public class AuthorizationRules<T>
{
    public List<RequiredPermission> RequiredPermissions { get; } = [];
    public List<RequiredResourcePermission<T>> RequiredResourcePermissions { get; } = [];
    public List<RequiredFeatureFlag> RequiredFeatureFlags { get; } = [];
}