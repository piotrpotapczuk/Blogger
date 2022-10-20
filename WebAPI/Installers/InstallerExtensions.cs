using Microsoft.AspNetCore.Hosting;

namespace WebAPI.Installers
{
    public static class InstallerExtensions
    {
        // https://dev.to/tomfletcher9/net-6-register-services-using-reflection-3156
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            
            var installers = typeof(Program).Assembly.ExportedTypes.Where(x =>
                typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            installers.ForEach(installer => installer.InstallServices(services, configuration));
        }
    }
}
