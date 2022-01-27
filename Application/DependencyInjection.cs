using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IPostService, PostService>();
            Assembly assemblies = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assemblies);
            // można tak - przekazujemy typ klasy ktora dziecziny po Profile i gdzie w konstrutorze są tworzone wszyskie obiekty mapowania
            //services.AddAutoMapper(typeof(MappingProfile));

            //stara wersja
            //services.AddSingleton(AutoMapperConfig_NOT_USED.Initlialize());

            return services;
        }
    }
}
