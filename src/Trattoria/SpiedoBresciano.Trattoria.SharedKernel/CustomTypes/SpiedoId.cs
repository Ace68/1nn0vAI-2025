using Muflone.Core;

namespace SpiedoBresciano.Trattoria.SharedKernel.CustomTypes;

public sealed class SpiedoId : DomainId
{
    public SpiedoId(Guid value) : base(value.ToString())
    {
        GuidValue = value;
    }

    public SpiedoId(string value) : base(value)
    {
        GuidValue = Guid.Parse(value);
    }

    public Guid GuidValue { get; }

    public static SpiedoId Empty => new(Guid.Empty);
    public static SpiedoId New => new(Guid.NewGuid());
}