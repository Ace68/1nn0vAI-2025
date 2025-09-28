using Muflone.Messages.Commands;
using SpiedoBresciano.Trattoria.SharedKernel.CustomTypes;

namespace SpiedoBresciano.Shared.Messages.Commands;

public sealed class UngiCarne : Command
{
    public SpiedoId SpiedoId { get; }
    public double QuantitaOlio { get; }
    public DateTime DataOperazione { get; }

    public UngiCarne(SpiedoId spiedoId, double quantitaOlio, DateTime dataOperazione) : base(SpiedoId.New)
    {
        SpiedoId = spiedoId ?? throw new ArgumentNullException(nameof(spiedoId));
        QuantitaOlio = quantitaOlio;
        DataOperazione = dataOperazione;
    }
}