using Muflone.Messages.Events;
using SpiedoBresciano.Trattoria.SharedKernel.CustomTypes;

namespace SpiedoBresciano.Shared.Messages.Events;

public sealed class GirarrostoAcceso : DomainEvent
{
    public SpiedoId SpiedoId { get; }
    public DateTime DataAccensione { get; }

    public GirarrostoAcceso(SpiedoId spiedoId, DateTime dataAccensione) : base(SpiedoId.New)
    {
        SpiedoId = spiedoId ?? throw new ArgumentNullException(nameof(spiedoId));
        DataAccensione = dataAccensione;
    }
}