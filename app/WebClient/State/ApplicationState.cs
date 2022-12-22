namespace app.WebClient.State;

public enum UserTypes
{
    Guest,
    Admin,
    Abonent,
}

public class ApplicationState
{
    public bool IsAuth { get; set; }
    
    public bool IsInit { get; set; }
    
    public string Email { get; set; }
    
    public UserTypes UserType { get; set; }

    public void InitApp(UserTypes uType, string email)
    {
        UserType = uType;
        IsInit = true;
        Email = email;
    }

    public ApplicationState()
    {
        IsAuth = false;
    }

}