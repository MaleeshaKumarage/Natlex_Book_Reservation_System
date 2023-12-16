using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection serviceDescriptors)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            serviceDescriptors.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly));
            serviceDescriptors.AddValidatorsFromAssembly(assembly);
            return serviceDescriptors;
        }
    }
}
