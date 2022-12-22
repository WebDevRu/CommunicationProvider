using app.Core.Model;

namespace app.Core.Services;

public struct GetSubscriberArgs
{
    public string Email;
}

public class SubscriberAuth
{
    MasterContext dbContext = new ();

    public Abonent PostLogin(LoginArgs args)
    {
        var subscriber = dbContext.Abonents.Where(
            a => a.Email == args.Login && a.Password == args.Password
        ).FirstOrDefault();

        if (subscriber != null)
        {
            return subscriber;
        }

        throw new InvalidOperationException("Logfile cannot be read-only");;
    }

    public Abonent GetSubscriber(GetSubscriberArgs args)
    {
        return dbContext.Abonents.Where((a) => a.Email == args.Email).FirstOrDefault();
    }
}