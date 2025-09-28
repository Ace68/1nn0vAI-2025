using Muflone.Messages.Events;
using SpiedoBresciano.Trattoria.SharedKernel.CustomTypes;

namespace SpiedoBresciano.Shared.Messages.Events;

public sealed class BraceRinnovata : DomainEvent
{
    public SpiedoId SpiedoId { get; }
    public DateTime DataOperazione { get; }

    public BraceRinnovata(SpiedoId spiedoId, DateTime dataOperazione) : base(SpiedoId.New)
    {
        SpiedoId = spiedoId ?? throw new ArgumentNullException(nameof(spiedoId));
        DataOperazione = dataOperazione;
    }
}