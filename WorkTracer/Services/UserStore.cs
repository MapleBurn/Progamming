using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
                //Id = 1,
                Username = "Admin",
                Password = new PasswordHasher<ApplicationUser>().HashPassword(null, "Password123"),
                Email = "ADMIN@ADMIN.CZ"
            };

            dbContext.Users.Add(defaultUser);
            dbContext.SaveChanges();
        }
    }

    private UserRecord ToDbUser(ApplicationUser user)
    {
        return new UserRecord()
        {
            Username = user.NormalizedUserName,
            Password = user.PasswordHash,
            Email = user.NormalizedEmail
        };
    }

    public ApplicationUser? FromDbUser(UserRecord? user)
    {
        if (user == null)
            return null;
        
        return new ApplicationUser()
        {
            UserName = user.Username,
            NormalizedUserName = user.Username,
            Email = user.Email,
            NormalizedEmail = user.Email,
            PasswordHash = user.Password
        };
    }

    public async Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        if (await _dbContext.Users.AnyAsync(u => u.Username == user.NormalizedUserName, cancellationToken))
            return IdentityResult.Failed(new IdentityError { Description = $"User {user.UserName} already exists." });
        
        await _dbContext.Users.AddAsync(ToDbUser(user));
        await _dbContext.SaveChangesAsync();
        
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
        var dbUser = _dbContext.Users.FirstOrDefault(u => u.Username == normalizedUserName);
        return Task.FromResult(FromDbUser(dbUser));
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