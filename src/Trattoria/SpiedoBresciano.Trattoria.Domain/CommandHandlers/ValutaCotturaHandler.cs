using Muflone.Messages.Commands;
using Muflone.Persistence;
using SpiedoBresciano.Shared.Messages.Commands;
using SpiedoBresciano.Trattoria.Domain.Aggregates;
using SpiedoBresciano.Trattoria.SharedKernel.CustomTypes;

namespace SpiedoBresciano.Trattoria.Domain.CommandHandlers;

public sealed class ValutaCotturaHandler : ICommandHandlerAsync<ValutaCottura>, IDisposable
{
    private readonly IRepository _repository;

    public ValutaCotturaHandler(IRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task HandleAsync(ValutaCottura command, CancellationToken cancellationToken = default)
    {
        var spiedo = await _repository.GetByIdAsync<Spiedo>(command.SpiedoId, cancellationToken);
        if (spiedo == null)
            throw new InvalidOperationException($"Spiedo with ID {command.SpiedoId} not found");

        spiedo.ValutaCottura(command.DataOperazione, command.TemperaturaCarne);

        await _repository.SaveAsync(spiedo, Guid.NewGuid(), cancellationToken);
    }

    public void Dispose()
    {
        // No resources to dispose
    }
}