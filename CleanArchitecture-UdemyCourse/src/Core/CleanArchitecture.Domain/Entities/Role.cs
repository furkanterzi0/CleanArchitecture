using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Domain.Entities;

public class Role: IdentityRole<string>
{
    public Role()
    {
        Id = Guid.NewGuid().ToString();
    }
}
