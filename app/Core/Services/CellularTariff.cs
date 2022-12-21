namespace app.Core.Services;
using app.Core.Model;
using System.Text.Json;

public struct CreateCellularTariffArgs
{
    public string Title;
    public string Description;
    public int PeriodPaymentAmount;
    public int PeriodSeconds;
    public int MobileInternetLimitMb;
    public int MobileCallsMinutes;
}

public struct EditCellularTariffArgs
{
    public int TariffId;
    public string Title;
    public string Description;
    public int PeriodPaymentAmount;
    public int PeriodSeconds;
    public int MobileInternetLimitMb;
    public int MobileCallsMinutes;
}
public class CellularTariff
{
    MasterContext dbContext = new ();
    
    public void CreateCellularTariff(CreateCellularTariffArgs args)
    {
        var limit = new Limit
        {
            IsSystem = false, 
            ServiceType = JsonSerializer.Serialize(ServiceTypes.Cellular),
            MobileInternetLimitMb = args.MobileInternetLimitMb,
            MobileCallsMinutes = args.MobileCallsMinutes,
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
            ServiceType = JsonSerializer.Serialize(ServiceTypes.Cellular),
        };

        dbContext.Add<Tariff>(tariff);
        dbContext.SaveChanges();
    }

    public void EditCellularTariff(EditCellularTariffArgs args)
    {
        Tariff? tariff = dbContext.Tariffs.First(x => x.Id == args.TariffId);

        tariff.Title = args.Title;
        tariff.Description = args.Description;
        tariff.PeriodPaymentAmount = args.PeriodPaymentAmount;
        tariff.PeriodSeconds = args.PeriodSeconds;

        dbContext.SaveChanges();
    }

    public Tariff[] GetTariffs()
    {
        return dbContext.Tariffs
            .Select((t) => t)
            .Where((t) => t.ServiceType == "2")
            .ToArray();
    }

    public void DeleteTariff(int tariffId)
    {
        Tariff? tariff = dbContext.Tariffs.First(x => x.Id == tariffId);
        if (tariff != null)
        {
            dbContext.Tariffs.Remove(tariff);
            dbContext.SaveChanges();
        }
    }
    
    public Tariff[] GetTariffsFilters(TariffsFiltersArgs args)
    {
        return dbContext.Tariffs
            .Select((t) => t)
            .Where((t) => t.ServiceType == "2")
            .Where((t) => t.PeriodPaymentAmount <= args.PeriodPaymentAmount)
            .ToArray();
    }
}