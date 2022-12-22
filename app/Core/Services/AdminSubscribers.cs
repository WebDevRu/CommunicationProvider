using OneOf.Types;

namespace app.Core.Services;
using app.Core.Model;
using System.Text.Json;

public struct AddSubscriberArgs
{
    public string Email;

    public string Password;

    public string FirstName;

    public string LastName;
}

public class AdminSubscribers
{
    MasterContext dbContext = new ();

    public void AddSubscriber(AddSubscriberArgs args)
    {
        var user = new Abonent
        {
            Email = args.Email,
            Password = args.Password, 
            IsPasswordTemporary = true, 
            Status = "active", 
            FirstName = args.FirstName,  
            LastName = args.LastName,  
            Address = DateTime.Now,
            LastLoginAt = DateTime.Now,
        };
        
        dbContext.Add<Abonent>(user);
        dbContext.SaveChanges();
    }

    public Abonent[] GetSubscribers()
    {
        return dbContext.Abonents
            .Select((a) => a)
            .ToArray();
    }
}