namespace app.Core.Services;

public struct LoginArgs
{
    public string Login;
    public string Password;
}

public class AdminAuth
{
    public static async void PostLogin(LoginArgs args)
    {
        Console.WriteLine(args.Login);
        Console.WriteLine(args.Password);
    }

}