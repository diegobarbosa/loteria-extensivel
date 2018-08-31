using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Agenda.Core.Infra
{
    public class AppConfig
    {
        public static IConfiguration Configuration { get; set; }

        public static string ConnectionString => AppConfig.Configuration["ConnectionStrings:DefaultConnection"];
    }
}
