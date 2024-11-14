namespace FluentPermission.Abstractions;

public interface IFeatureManager
{
    Task<bool> IsEnabledAsync(string featureName);
}