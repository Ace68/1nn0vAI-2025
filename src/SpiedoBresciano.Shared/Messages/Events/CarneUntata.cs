using Muflone.Messages.Events;
using SpiedoBresciano.Trattoria.SharedKernel.CustomTypes;

namespace SpiedoBresciano.Shared.Messages.Events;

public sealed class CarneUntata : DomainEvent
{
    public SpiedoId SpiedoId { get; }
    public double QuantitaOlio { get; }
    public DateTime DataOperazione { get; }

    public CarneUntata(SpiedoId spiedoId, double quantitaOlio, DateTime dataOperazione) : base(SpiedoId.New)
    {
        SpiedoId = spiedoId ?? throw new ArgumentNullException(nameof(spiedoId));
        QuantitaOlio = quantitaOlio;
        DataOperazione = dataOperazione;
    }
}