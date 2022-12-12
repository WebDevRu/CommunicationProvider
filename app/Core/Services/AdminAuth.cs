using app.Core.Model;

namespace app.Core.Services;
public struct LoginArgs
{
    public string Login;
    public string Password;
}

public class AdminAuth
{
    MasterContext dbContext = new ();

    public async void PostLogin(LoginArgs args)
    {
        var admin = dbContext.Admins.Where(
            a => a.Email == args.Login && a.Password == args.Password
        ).FirstOrDefault();
        
    }

}