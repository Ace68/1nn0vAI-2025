using Muflone.Messages.Commands;
using SpiedoBresciano.Trattoria.SharedKernel.CustomTypes;

namespace SpiedoBresciano.Shared.Messages.Commands;

public sealed class ValutaCottura : Command
{
    public SpiedoId SpiedoId { get; }
    public Temperature TemperaturaRilevata { get; }
    public DateTime DataValutazione { get; }
    public bool CotturaCompletata { get; }

    public ValutaCottura(SpiedoId spiedoId, Temperature temperaturaRilevata, DateTime dataValutazione, bool cotturaCompletata) : base(SpiedoId.New)
    {
        SpiedoId = spiedoId ?? throw new ArgumentNullException(nameof(spiedoId));
        TemperaturaRilevata = temperaturaRilevata ?? throw new ArgumentNullException(nameof(temperaturaRilevata));
        DataValutazione = dataValutazione;
        CotturaCompletata = cotturaCompletata;
    }
}