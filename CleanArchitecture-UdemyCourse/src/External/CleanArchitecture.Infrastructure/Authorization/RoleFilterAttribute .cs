using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Infrastructure.Authorization;

public class RoleFilterAttribute : TypeFilterAttribute
{
    public RoleFilterAttribute(string role) : base(typeof(RoleAttribute))
    {
        Arguments = new object[] { role }; 
    }
}
