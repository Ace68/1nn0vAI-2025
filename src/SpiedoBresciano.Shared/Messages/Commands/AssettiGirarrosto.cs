using Muflone.Messages.Commands;
using SpiedoBresciano.Trattoria.SharedKernel.CustomTypes;

namespace SpiedoBresciano.Shared.Messages.Commands;

public sealed class AssettiGirarrosto : Command
{
    public SpiedoId SpiedoId { get; }
    public DateTime DataAccensione { get; }

    public AssettiGirarrosto(SpiedoId spiedoId, DateTime dataAccensione) : base(SpiedoId.New)
    {
        SpiedoId = spiedoId ?? throw new ArgumentNullException(nameof(spiedoId));
        DataAccensione = dataAccensione;
    }
}