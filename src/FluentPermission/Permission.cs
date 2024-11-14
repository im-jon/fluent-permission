namespace FluentPermission;

public record Permission
{
    public string Value { get; }
    
    private Permission(string Value)
    {
        this.Value = Value;
    }
    
    public static Permission CreateNew(string value) => new(value);
}