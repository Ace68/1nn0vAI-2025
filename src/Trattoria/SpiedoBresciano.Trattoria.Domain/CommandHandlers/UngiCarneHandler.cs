using Muflone.Messages.Commands;
using Muflone.Persistence;
using SpiedoBresciano.Shared.Messages.Commands;
using SpiedoBresciano.Trattoria.Domain.Aggregates;
using SpiedoBresciano.Trattoria.SharedKernel.CustomTypes;

namespace SpiedoBresciano.Trattoria.Domain.CommandHandlers;

public sealed class UngiCarneHandler : ICommandHandlerAsync<UngiCarne>, IDisposable
{
    private readonly IRepository _repository;

    public UngiCarneHandler(IRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task HandleAsync(UngiCarne command, CancellationToken cancellationToken = default)
    {
        var spiedo = await _repository.GetByIdAsync<Spiedo>(command.SpiedoId, cancellationToken);
        if (spiedo == null)
            throw new InvalidOperationException($"Spiedo with ID {command.SpiedoId} not found");

        spiedo.UngiCarne(command.QuantitaOlio, command.DataOperazione);

        await _repository.SaveAsync(spiedo, Guid.NewGuid(), cancellationToken);
    }

    public void Dispose()
    {
        // No resources to dispose
    }
}