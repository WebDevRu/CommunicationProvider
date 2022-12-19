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
            ServiceType = JsonSerializer.Serialize(ServiceTypes.InternetTV),
        };

        dbContext.Add<Tariff>(tariff);
        dbContext.SaveChanges();
    }
}