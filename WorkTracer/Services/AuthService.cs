public class AuthService
{
    public bool isLoggedIn = false;
    public bool Login(string username, string password)
    {
        if (username == "admin" && password == "admin")
        {
            isLoggedIn = true;
            return true;
        }
        else
        {
            return false;
        }   
    }
    public void Logout()
    {
        isLoggedIn = false;
    }
}