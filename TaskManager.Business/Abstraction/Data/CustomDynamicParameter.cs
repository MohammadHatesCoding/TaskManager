using System.Data;

namespace TaskManager.Business.Abstraction.Data;

public class CustomDynamicParameter
{
    public string Name { get; }
    public object? Value { get; }
    public ParameterDirection Direction { get; }

    public CustomDynamicParameter(string name, object? value, ParameterDirection direction = ParameterDirection.Input)
    {
        Name = name;
        Value = value;
        Direction = direction;
    }
}

public class CustomDynamicParameters
{
    private readonly List<CustomDynamicParameter> _params = new();

    public void Add(string name, object? value, ParameterDirection direction = ParameterDirection.Input)
        => _params.Add(new CustomDynamicParameter(name, value, direction));

    public IReadOnlyList<CustomDynamicParameter> AsList() => _params;
}