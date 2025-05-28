using Microsoft.AspNetCore.Identity;
using WorkTracer.Data;

namespace WorkTracer.Services;

public class UserStore : IUserStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>
{
    private ApplicationDbContext _dbContext;
    private readonly Dictionary<string, ApplicationUser> _users = new();

    public UserStore(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        //var user = new ApplicationUser
        //{
            // Id = "1",
            // UserName = "aaa",
            // NormalizedUserName = "AAA",
            // Email = "aaa@aaa.cz",
            // NormalizedEmail = "AAA@AAA.CZ",
            // PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "aaa")
        //};

        //_users[user.Id] = user;

        if (!dbContext.Users.Any())
        {
            var defaultUser = new UserRecord()
            {
                Id = 1,
                Username = "admin",
                Password = new PasswordHasher<ApplicationUser>().HashPassword(null, "Password123"),
                Email = "admin@admin.cz"
            };

            dbContext.Users.Add(defaultUser);
        }
    }

    private UserRecord ToDbUser(ApplicationUser user)
    {
        return new UserRecord()
        {
            Username = user.UserName,
            Password = user.PasswordHash,
            Email = user.Email
        };
    }

    private ApplicationUser FromDbUser(UserRecord user)
    {
        return new ApplicationUser()
        {
            UserName = user.Username,
            NormalizedUserName = user.Username.ToUpper(),
            Email = user.Email,
            NormalizedEmail = user.Email.ToUpper(),
            PasswordHash = user.Password
        };
    }

    public async Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        await _dbContext.Users.AddAsync(ToDbUser(user));
        return IdentityResult.Success;
    }

    public Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        _dbContext.Users.Remove(ToDbUser(user));
        return Task.FromResult(IdentityResult.Success);
    }

    public Task<ApplicationUser?> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        _users.TryGetValue(userId, out var user);
        return Task.FromResult(user);
    }

    public Task<ApplicationUser?> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        var user = _users.Values.FirstOrDefault(u => u.NormalizedUserName == normalizedUserName);
        return Task.FromResult(user);
    }

    public Task<string?> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.NormalizedUserName);
    }

    public Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.Id);
    }

    public Task<string?> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.UserName);
    }

    public Task SetNormalizedUserNameAsync(ApplicationUser user, string normalizedName, CancellationToken cancellationToken)
    {
        user.NormalizedUserName = normalizedName;
        return Task.CompletedTask;
    }

    public Task SetUserNameAsync(ApplicationUser user, string userName, CancellationToken cancellationToken)
    {
        user.UserName = userName;
        return Task.CompletedTask;
    }

    public Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        _users[user.Id] = user;
        return Task.FromResult(IdentityResult.Success);
    }

    // Required for IUserPasswordStore
    public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash, CancellationToken cancellationToken)
    {
        user.PasswordHash = passwordHash;
        return Task.CompletedTask;
    }

    public Task<string?> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.PasswordHash);
    }

    public Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
    }

    public void Dispose()
    {
        // Nothing to dispose in this example
    }
}