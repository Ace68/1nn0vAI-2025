using Muflone.Messages.Events;
using SpiedoBresciano.Trattoria.SharedKernel.CustomTypes;

namespace SpiedoBresciano.Shared.Messages.Events;

public sealed class ImprevistroRisolto : DomainEvent
{
    public SpiedoId SpiedoId { get; }
    public string Descrizione { get; }
    public DateTime DataRisoluzione { get; }

    public ImprevistroRisolto(SpiedoId spiedoId, string descrizione, DateTime dataRisoluzione) : base(SpiedoId.New)
    {
        SpiedoId = spiedoId ?? throw new ArgumentNullException(nameof(spiedoId));
        Descrizione = descrizione ?? throw new ArgumentNullException(nameof(descrizione));
        DataRisoluzione = dataRisoluzione;
    }
}