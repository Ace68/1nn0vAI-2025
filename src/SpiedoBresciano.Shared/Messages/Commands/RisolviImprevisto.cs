using Muflone.Messages.Commands;
using SpiedoBresciano.Trattoria.SharedKernel.CustomTypes;

namespace SpiedoBresciano.Shared.Messages.Commands;

public sealed class RisolviImprevisto : Command
{
    public SpiedoId SpiedoId { get; }
    public string Descrizione { get; }
    public DateTime DataRisoluzione { get; }

    public RisolviImprevisto(SpiedoId spiedoId, string descrizione, DateTime dataRisoluzione) : base(SpiedoId.New)
    {
        SpiedoId = spiedoId ?? throw new ArgumentNullException(nameof(spiedoId));
        Descrizione = descrizione ?? throw new ArgumentNullException(nameof(descrizione));
        DataRisoluzione = dataRisoluzione;
    }
}