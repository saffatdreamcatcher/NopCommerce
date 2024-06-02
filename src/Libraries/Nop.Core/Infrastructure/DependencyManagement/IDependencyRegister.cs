using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Configuration;

namespace Nop.Core.Infrastructure.DependencyManagement;
public interface IDependencyRegister
{
    /// <summary>
    /// Register services and interfaces
    /// </summary>
    /// <param name="services">Collection of service descriptors</param>
    /// <param name="typeFinder">Type finder</param>
    /// <param name="appSettings">App settings</param>
    void Register(IServiceCollection services, ITypeFinder typeFinder, AppSettings appSettings);

    /// <summary>
    /// Gets order of this dependency registrar implementation
    /// </summary>
    int Order { get; }
}
