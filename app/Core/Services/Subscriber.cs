using app.Core.Model;

namespace app.Core.Services;

public struct GetSubscriberArgs
{
    public string Email;
}

public struct EditSubscriberArgs
{
    public string Email;
    public string Password;
    public string FirstName;
    public string LastName;
}

public class SubscriberService
{
    MasterContext dbContext = new ();

    public Abonent GetSubscriber(GetSubscriberArgs args)
    {
        return dbContext.Abonents.Where((a) => a.Email == args.Email).FirstOrDefault();
    }

    public void EditSubscriber(EditSubscriberArgs args)
    {
        Abonent? subscriber = dbContext.Abonents.First(x => x.Email == args.Email);

        subscriber.Email = args.Email;
        subscriber.Password = args.Password;
        subscriber.FirstName = args.FirstName;
        subscriber.LastName = args.LastName;

        dbContext.SaveChanges();
    }
 }