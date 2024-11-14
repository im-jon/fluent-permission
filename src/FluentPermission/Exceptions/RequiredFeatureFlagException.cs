namespace FluentPermission.Exceptions;

public class RequiredFeatureFlagException(string featureName) : Exception($"Feature flag {featureName} is required to access this resource.");