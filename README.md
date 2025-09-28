# SpiedoBresciano API

Una API REST per la gestione dello Spiedo Bresciano, sviluppata seguendo i principi del Domain-Driven Design con un'architettura modulare.

## Architettura

La soluzione è organizzata seguendo una struttura modulare con separazione chiara dei bounded context:

### Solution Folders

- **90 Presentation**: Contiene il progetto REST API principale
- **80 Infrastructure**: Progetti per l'accesso ai dati e implementazioni dei repository
- **50 Modules**: Moduli di dominio organizzati per bounded context
  - **Macelleria**: Gestione della macelleria
  - **Trattoria**: Gestione della trattoria
- **30 Shared**: Progetti condivisi tra tutti i moduli

### Progetti per Modulo

Ogni modulo (Macelleria e Trattoria) ha la seguente struttura:
- **Facade**: Espone gli endpoints e le interfacce del modulo
- **Domain**: Entità e logiche di dominio
- **SharedKernel**: Classi e interfacce condivise all'interno del modulo
- **ReadModel**: Classi per query e proiezioni
- **Infrastructure**: Implementazioni per accesso ai dati
- **Tests**: Test architetturali per verificare l'isolamento dei moduli

## Tecnologie Utilizzate

- **.NET 9**: Framework di sviluppo
- **Minimal APIs**: Per l'implementazione degli endpoint REST
- **OpenAPI/Swagger**: Documentazione automatica delle API
- **Scalar**: Interfaccia per la visualizzazione della documentazione API
- **OpenTelemetry**: Telemetria e monitoraggio (opzionale)
- **Serilog**: Logging strutturato
- **NetArchTest**: Test architetturali per verificare le dipendenze
- **xUnit**: Framework per i test

## Esecuzione Locale

### Prerequisiti

- .NET 9 SDK installato

### Avvio dell'applicazione

1. Clona il repository:
   ```bash
   git clone <repository-url>
   cd Pordenone
   ```

2. Naviga nella cartella src:
   ```bash
   cd src
   ```

3. Compila la soluzione:
   ```bash
   dotnet build
   ```

4. Esegui i test architetturali:
   ```bash
   dotnet test
   ```

5. Avvia l'applicazione:
   ```bash
   cd SpiedoBresciano.Rest
   dotnet run
   ```

L'applicazione sarà disponibile su:
- **HTTP**: `http://localhost:5000`
- **Documentazione API**: `http://localhost:5000/scalar/v1`
- **OpenAPI JSON**: `http://localhost:5000/openapi/v1.json`

## Endpoints Disponibili

### Macelleria
- `GET /v1/macelleria/` - Stato del modulo Macelleria

### Trattoria  
- `GET /v1/trattoria/` - Stato del modulo Trattoria

## Configurazione

### Configurazione Base (appsettings.json)

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "sqlServer": "",
    "applicationInsights": ""
  }
}
```

### OpenTelemetry

Il modulo OpenTelemetry è attualmente disabilitato per default. Per abilitarlo:

1. Modifica il file `SpiedoBresciano.Rest/Modules/OpenTelemetryModule.cs`
2. Cambia `IsEnabled` da `false` a `true`
3. Configura la connection string per Application Insights in `appsettings.json`

## Test Architetturali

La soluzione include test architetturali che verificano:

1. **Isolamento dei moduli**: Nessun modulo può fare riferimento a progetti di altri moduli
2. **Convenzioni dei namespace**: Tutti i tipi devono seguire le convenzioni di naming
3. **Dipendenze corrette**: Il progetto REST può dipendere solo dai Facade dei moduli

Per eseguire i test:
```bash
dotnet test
```

## Sviluppo

### Aggiungere nuovi endpoint

1. Modifica il file `Endpoints/{Modulo}Endpoints.cs` nel progetto Facade appropriato
2. Registra i servizi necessari nel `{Modulo}FacadeHelper.cs`
3. I moduli vengono automaticamente registrati e configurati tramite il sistema di moduli

### Struttura dei Moduli

Il sistema utilizza l'interfaccia `IModule` per la registrazione automatica dei moduli:

```csharp
public interface IModule
{
    bool IsEnabled { get; }
    int Order { get; }
    IServiceCollection Register(WebApplicationBuilder builder);
    WebApplication Configure(WebApplication app);
}
```

## Versioning API

- Strategia attuale: path-based (`/v1`)
- Versione inclusa nel titolo OpenAPI: "SpiedoBresciano API v1"
- Server URL base: `/` per compatibilità con reverse proxy

## Logging

Configurato con Serilog per:
- Output su console
- File di log con rotazione giornaliera
- Formato JSON strutturato per i log su file