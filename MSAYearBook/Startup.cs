using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MSAYearBook.Data;
using MSAYearBook.GraphQL.Comments;
using MSAYearBook.GraphQL.Projects;
using MSAYearBook.GraphQL.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSAYearBook
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services
                .AddGraphQLServer()
                .AddQueryType(d => d.Name("Query"))
                    .AddTypeExtension<ProjectQueries>()
                    .AddTypeExtension<StudentQueries>()
                .AddMutationType(d => d.Name("Mutation"))
                    .AddTypeExtension<StudentMutations>()
                    .AddTypeExtension<ProjectMutations>()
                    .AddTypeExtension<CommentMutations>()
                .AddType<ProjectType>()
                .AddType<StudentType>()
                .AddType<CommentType>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app
               .UseRouting()
               .UseEndpoints(endpoints =>
               {
                   endpoints.MapGraphQL();
               });
        }
    }
}
