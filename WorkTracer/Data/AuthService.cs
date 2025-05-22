public class AuthService
{
    public bool isLoggedIn = false;
    public Task<bool> Login(string username, string password)
    {
        if (username == "admin" && password == "admin")
        {
            isLoggedIn = true;
            return Task.FromResult(true);
        }
        else
        {
            return Task.FromResult(false);
        }

        public void Logout()
        {
            isLoggedIn = false;
        }
    }
}