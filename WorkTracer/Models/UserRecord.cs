using System.Text.Json;
using System.Text.Json.Serialization;


public class UserRecord
{
    public string Username {get; set;}
    public string Password {get; set;}
    private readonly List<UserRecord> users;
    
    public UserRecord()
    {
        // adjust the path as needed
        var path = "../WorkTracer/wwwroot/resources/users.json";
        var json = File.ReadAllText(path);
        users = JsonSerializer.Deserialize<List<UserRecord>>(json) ?? new List<UserRecord>();
    }

    public Task<bool> ValidateCredentialsAsync(string userName, string password)
    {
        // simple plain-text match
        if (users.Any(u => u.Username == userName && u.Password == password))
        {
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
}