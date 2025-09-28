using Muflone.Messages.Commands;
using Muflone.Persistence;
using SpiedoBresciano.Shared.Messages.Commands;
using SpiedoBresciano.Trattoria.Domain.Aggregates;
using SpiedoBresciano.Trattoria.SharedKernel.CustomTypes;

namespace SpiedoBresciano.Trattoria.Domain.CommandHandlers;

public sealed class RisolviImprevistoHandler : ICommandHandlerAsync<RisolviImprevisto>, IDisposable
{
    private readonly IRepository _repository;

    public RisolviImprevistoHandler(IRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task HandleAsync(RisolviImprevisto command, CancellationToken cancellationToken = default)
    {
        var spiedo = await _repository.GetByIdAsync<Spiedo>(command.SpiedoId, cancellationToken);
        if (spiedo == null)
            throw new InvalidOperationException($"Spiedo with ID {command.SpiedoId} not found");

        spiedo.RisolviImprevisto(command.DataOperazione, command.Descrizione);

        await _repository.SaveAsync(spiedo, Guid.NewGuid(), cancellationToken);
    }

    public void Dispose()
    {
        // No resources to dispose
    }
}