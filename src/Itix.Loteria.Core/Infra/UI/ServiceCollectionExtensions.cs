using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Agenda.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IMvcBuilder AddFeatureFolders(this IMvcBuilder services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddRazorOptions(o =>
            {
                o.ViewLocationExpanders.Add(new FeatureViewLocationExpander());
            });

            return services;
        }
    }
}
