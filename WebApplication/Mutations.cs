using System.Security.Claims;

namespace WebApplication;

public class Mutations
{
    public async Task<bool> SaveSetting(
        [Service] IHttpContextAccessor httpContextAccessor,
        ClaimsPrincipal principal,
        Guid organizationId,
        string? iso639Code,
        string purpose,
        string slot,
        ParameterInput parameters
    )
    {
        return await Task.FromResult(true);
    }
}