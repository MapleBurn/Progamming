using System.Text.Json;
using System.Text.Json.Serialization;


public class UserRecord
{
    public string Username {get; set;}
    public string Password {get; set;}
    private static readonly List<UserRecord> users;

    static UserRecord()
    {
        var json = "{}";
        // adjust the path as needed
        var path = "../WorkTracer/wwwroot/resources/users.json";
        try
        {
            json = File.ReadAllText(path);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            using var sW = File.CreateText(path);
            sW.WriteLine("{}");
        }

        users = JsonSerializer.Deserialize<List<UserRecord>>(json) ?? new List<UserRecord>();
    }

    public UserRecord()
    {
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