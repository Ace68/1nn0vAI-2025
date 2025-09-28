namespace SpiedoBresciano.Trattoria.SharedKernel.CustomTypes;

public record SpiedoStatus
{
    public static readonly SpiedoStatus Acceso = new("Acceso");
    public static readonly SpiedoStatus Sospeso = new("Sospeso");
    public static readonly SpiedoStatus Terminato = new("Terminato");

    public string Value { get; }

    private SpiedoStatus(string value)
    {
        Value = value;
    }

    public override string ToString() => Value;

    public static implicit operator string(SpiedoStatus status) => status.Value;
}