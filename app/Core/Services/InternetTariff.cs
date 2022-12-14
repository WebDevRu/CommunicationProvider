namespace app.Core.Services;
using app.Core.Model;
using System.Text.Json;

enum ServiceTypes
{
    InternetTV,
    CabelInternet,
    Cellular,
}

enum TariffStatuses
{
    Active,
    Archived,
}

public struct AddTariffArgs
{
    public int SpeedMb;
    public string Title;
    public string Description;
    public int PeriodPaymentAmount;
    public int PeriodSeconds;
}

public struct TariffsFiltersArgs
{
    public int PeriodPaymentAmount;
}

public class InternetTariff
{
    MasterContext dbContext = new ();
    
    public void AddTariff(AddTariffArgs args)
    {
        var limit = new Limit
        {
            CableInternetSpeedMbs = args.SpeedMb, 
            IsSystem = false, 
            ServiceType = JsonSerializer.Serialize(ServiceTypes.CabelInternet),
        };
        dbContext.Add<Limit>(limit);
        dbContext.SaveChanges();

        var tariff = new Tariff
        {
            LimitId = limit.Id,
            Title = args.Title,
            Description = args.Description,
            InitialPaymentAmount = 0,
            PeriodSeconds = args.PeriodSeconds,
            PeriodPaymentAmount = args.PeriodPaymentAmount,
            Status = JsonSerializer.Serialize(TariffStatuses.Active),
            ServiceType = JsonSerializer.Serialize(ServiceTypes.CabelInternet),
        };

        dbContext.Add<Tariff>(tariff);
        dbContext.SaveChanges();
    }

    public Tariff[] GetTariffs()
    {
        return dbContext.Tariffs
            .Select((t) => t)
            .Where((t) => t.ServiceType == "1")
            .ToArray();
    }

    public Tariff[] GetTariffsFilters(TariffsFiltersArgs args)
    {
        return dbContext.Tariffs
            .Select((t) => t)
            .Where((t) => t.ServiceType == "1")
            .Where((t) => t.PeriodPaymentAmount <= args.PeriodPaymentAmount)
            .ToArray();
    }
}