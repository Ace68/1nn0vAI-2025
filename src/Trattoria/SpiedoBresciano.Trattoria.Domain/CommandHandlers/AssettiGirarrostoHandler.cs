using Muflone.Messages.Commands;
using Muflone.Persistence;
using SpiedoBresciano.Shared.Messages.Commands;
using SpiedoBresciano.Trattoria.Domain.Aggregates;
using SpiedoBresciano.Trattoria.SharedKernel.CustomTypes;

namespace SpiedoBresciano.Trattoria.Domain.CommandHandlers;

public sealed class AssettiGirarrostoHandler : ICommandHandlerAsync<AssettiGirarrosto>, IDisposable
{
    private readonly IRepository _repository;

    public AssettiGirarrostoHandler(IRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task HandleAsync(AssettiGirarrosto command, CancellationToken cancellationToken = default)
    {
        var spiedo = await _repository.GetByIdAsync<Spiedo>(command.SpiedoId, cancellationToken)
                     ?? Spiedo.Create(command.SpiedoId);

        spiedo.AssettiGirarrosto(command.DataAccensione);

        await _repository.SaveAsync(spiedo, Guid.NewGuid(), cancellationToken);
    }

    public void Dispose()
    {
        // No resources to dispose
    }
}