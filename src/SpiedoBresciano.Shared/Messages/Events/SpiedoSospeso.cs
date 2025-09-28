using Muflone.Messages.Events;
using SpiedoBresciano.Trattoria.SharedKernel.CustomTypes;

namespace SpiedoBresciano.Shared.Messages.Events;

public sealed class SpiedoSospeso : DomainEvent
{
    public SpiedoId SpiedoId { get; }
    public string MotivoSospensione { get; }
    public DateTime DataSospensione { get; }

    public SpiedoSospeso(SpiedoId spiedoId, string motivoSospensione, DateTime dataSospensione) : base(SpiedoId.New)
    {
        SpiedoId = spiedoId ?? throw new ArgumentNullException(nameof(spiedoId));
        MotivoSospensione = motivoSospensione ?? throw new ArgumentNullException(nameof(motivoSospensione));
        DataSospensione = dataSospensione;
    }
}