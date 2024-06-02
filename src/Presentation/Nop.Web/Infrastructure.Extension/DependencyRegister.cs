using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Web.Areas.Admin.Factories.Extension;

namespace Nop.Web.Infrastructure.Extension;

public class DependencyRegister : IDependencyRegister
{
    /// <summary>
    /// Register services and interfaces
    /// </summary>
    /// <param name="services">Collection of service descriptors</param>
    /// <param name="typeFinder">Type finder</param>
    /// <param name="appSettings">App settings</param>
    public virtual void Register(IServiceCollection services, ITypeFinder typeFinder, AppSettings appSettings)
    {
        services.AddScoped<IHomePageSliderFactory, HomePageSliderFactory>();
       
    }

    /// <summary>
    /// Gets order of this dependency registrar implementation
    /// </summary>
    public int Order => 0;
}
