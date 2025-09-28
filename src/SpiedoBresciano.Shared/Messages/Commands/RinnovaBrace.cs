using Muflone.Messages.Commands;
using SpiedoBresciano.Trattoria.SharedKernel.CustomTypes;

namespace SpiedoBresciano.Shared.Messages.Commands;

public sealed class RinnovaBrace : Command
{
    public SpiedoId SpiedoId { get; }
    public DateTime DataOperazione { get; }

    public RinnovaBrace(SpiedoId spiedoId, DateTime dataOperazione) : base(SpiedoId.New)
    {
        SpiedoId = spiedoId ?? throw new ArgumentNullException(nameof(spiedoId));
        DataOperazione = dataOperazione;
    }
}