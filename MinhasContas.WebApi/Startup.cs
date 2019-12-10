using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace MinhasContas.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new Info
                {
                    Title = "MinhasContas.WebApi",
                    Description = "API REST criada com o ASP.NET Core para a aplicação Minhas Contas",
                    Version = "v1"
                });

                //string caminhoAplicacao =
                //    PlatformServices.Default.Application.ApplicationBasePath;
                //string nomeAplicacao =
                //    PlatformServices.Default.Application.ApplicationName;
                //string caminhoXmlDoc =
                //    Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                //o.IncludeXmlComments(caminhoXmlDoc);

            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "API Minhas Contas");
            });

            app.UseMvc();

        }
    }
}
