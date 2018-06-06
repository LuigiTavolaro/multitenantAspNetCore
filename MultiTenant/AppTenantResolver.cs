using Microsoft.AspNetCore.Http;
using SaasKit.Multitenancy;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenant
{
    public class AppTenantResolver : ITenantResolver<AppTenant>
    {
        IEnumerable<AppTenant> tenants = new List<AppTenant>(new[]
{
        new AppTenant {
            Name = "Tenant 1",
            HostNames = new[] { "localhost:6001" }
        },
        new AppTenant {
            Name = "Tenant 2",
            HostNames = new[] { "localhost:6002" }
        }
    });

        public async Task<TenantContext<AppTenant>> ResolveAsync(HttpContext context)
        {
            TenantContext<AppTenant> tenantContext = null;

            var tenant = tenants.FirstOrDefault(t =>
                t.HostNames.Any(h => h.Equals(context.Request.Host.Value.ToLower())));

            if (tenant != null)
            {
                tenantContext = new TenantContext<AppTenant>(tenant);
            }

            return tenantContext;
        }
    }
}
