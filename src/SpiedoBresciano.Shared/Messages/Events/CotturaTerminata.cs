using Muflone.Messages.Events;
using SpiedoBresciano.Trattoria.SharedKernel.CustomTypes;

namespace SpiedoBresciano.Shared.Messages.Events;

public sealed class CotturaTerminata : DomainEvent
{
    public SpiedoId SpiedoId { get; }
    public Temperature TemperaturaFinale { get; }
    public DateTime DataTerminazione { get; }

    public CotturaTerminata(SpiedoId spiedoId, Temperature temperaturaFinale, DateTime dataTerminazione) : base(SpiedoId.New)
    {
        SpiedoId = spiedoId ?? throw new ArgumentNullException(nameof(spiedoId));
        TemperaturaFinale = temperaturaFinale ?? throw new ArgumentNullException(nameof(temperaturaFinale));
        DataTerminazione = dataTerminazione;
    }
}