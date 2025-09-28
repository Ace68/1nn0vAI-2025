using Muflone.Core;
using SpiedoBresciano.Shared.Messages.Events;
using SpiedoBresciano.Trattoria.SharedKernel.CustomTypes;

namespace SpiedoBresciano.Trattoria.Domain.Aggregates;

public sealed class Spiedo : AggregateRoot
{
    public new SpiedoId Id { get; private set; }
    public SpiedoStatus Status { get; private set; }
    public DateTime? DataAccensione { get; private set; }
    public DateTime? UltimaOperazione { get; private set; }
    public Temperature? UltimaTemperaturaRilevata { get; private set; }

    public Spiedo(SpiedoId id) : base()
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
        Status = SpiedoStatus.Sospeso; // Default initial state
    }

    // Factory method per creare un nuovo spiedo
    public static Spiedo Create(SpiedoId id)
    {
        var spiedo = new Spiedo(id);
        return spiedo;
    }

    public void AssettiGirarrosto(DateTime dataAccensione)
    {
        if (Status != SpiedoStatus.Sospeso)
            throw new InvalidOperationException("Il girarrosto può essere acceso solo quando lo spiedo è sospeso");

        var @event = new GirarrostoAcceso(Id, dataAccensione);
        RaiseEvent(@event);
    }

    public void UngiCarne(double quantitaOlio, DateTime dataOperazione)
    {
        if (Status != SpiedoStatus.Acceso)
            throw new InvalidOperationException("La carne può essere unta solo durante la cottura");

        var @event = new CarneUntata(Id, quantitaOlio, dataOperazione);
        RaiseEvent(@event);
    }

    public void RinnovaBrace(DateTime dataOperazione)
    {
        if (Status != SpiedoStatus.Acceso)
            throw new InvalidOperationException("La brace può essere rinnovata solo durante la cottura");

        var @event = new BraceRinnovata(Id, dataOperazione);
        RaiseEvent(@event);
    }

    public void ValutaCottura(Temperature temperatura, DateTime dataValutazione, bool cotturaCompletata)
    {
        if (Status != SpiedoStatus.Acceso)
            throw new InvalidOperationException("La cottura può essere valutata solo durante la cottura");

        UltimaTemperaturaRilevata = temperatura;
        UltimaOperazione = dataValutazione;

        if (cotturaCompletata)
        {
            var @event = new CotturaTerminata(Id, temperatura, dataValutazione);
            RaiseEvent(@event);
        }
    }

    public void SospendiBySistemaEsterno(string motivo, DateTime dataSospensione)
    {
        if (Status != SpiedoStatus.Acceso)
            throw new InvalidOperationException("Lo spiedo può essere sospeso solo durante la cottura");

        var @event = new SpiedoSospeso(Id, motivo, dataSospensione);
        RaiseEvent(@event);
    }

    public void RisolviImprevisto(string descrizione, DateTime dataRisoluzione)
    {
        if (Status != SpiedoStatus.Sospeso)
            throw new InvalidOperationException("Un imprevisto può essere risolto solo quando lo spiedo è sospeso");

        var @event = new ImprevistroRisolto(Id, descrizione, dataRisoluzione);
        RaiseEvent(@event);
    }

    // Event handlers per aggiornare lo stato interno
    private void On(GirarrostoAcceso @event)
    {
        Status = SpiedoStatus.Acceso;
        DataAccensione = @event.DataAccensione;
        UltimaOperazione = @event.DataAccensione;
    }

    private void On(CarneUntata @event)
    {
        UltimaOperazione = @event.DataOperazione;
    }

    private void On(BraceRinnovata @event)
    {
        UltimaOperazione = @event.DataOperazione;
    }

    private void On(CotturaTerminata @event)
    {
        Status = SpiedoStatus.Terminato;
        UltimaTemperaturaRilevata = @event.TemperaturaFinale;
        UltimaOperazione = @event.DataTerminazione;
    }

    private void On(SpiedoSospeso @event)
    {
        Status = SpiedoStatus.Sospeso;
        UltimaOperazione = @event.DataSospensione;
    }

    private void On(ImprevistroRisolto @event)
    {
        Status = SpiedoStatus.Acceso; // Ritorna in cottura dopo aver risolto l'imprevisto
        UltimaOperazione = @event.DataRisoluzione;
    }
}