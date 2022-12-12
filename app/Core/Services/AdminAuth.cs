namespace app.Core.Services;
public struct LoginArgs
{
    public string Login;
    public string Password;
}

public class AdminAuth
{
    private DBContext dbContext;
    public AdminAuth(DBContext dbContext)
    {
        dbContext.Blogs.FirstOrDefault();
    }
    
    public async void PostLogin(LoginArgs args)
    {
        var blogs = dbContext.Blogs.Find();
        Console.WriteLine(blogs);
        Console.WriteLine(args.Login);
        Console.WriteLine(args.Password);
    }

}