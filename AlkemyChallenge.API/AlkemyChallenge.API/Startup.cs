using AlkemyChallenge.AccessData;
using AlkemyChallenge.AccessData.Commands;
using AlkemyChallenge.AccessData.Queries;
using AlkemyChallenge.Application;
using AlkemyChallenge.Application.Utils;
using AlkemyChallenge.Domain.Commands;
using AlkemyChallenge.Domain.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkemyChallenge.API
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
            services.AddControllers();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = Configuration["Jwt:Issuer"],
                      ValidAudience = Configuration["Jwt:Issuer"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                  };
              });


            //var sendGridAPIKey = Configuration.GetSection("").Value;
            //var EmailSender = Configuration.GetSection("").Value;


            var connectionString = Configuration.GetSection("ConnectionString").Value;
            services.AddDbContext<APIDbContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<IGenericsRepository, GenericsRepository>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ICharactersService, CharactersService>();
            services.AddTransient<IMoviesService, MoviesService>();
            services.AddTransient<IMoviesQueries, MoviesQueries>();
            services.AddTransient<ICharactersQueries, CharactersQueries>();
            services.AddTransient<ICharactersMoviesQueries,CharactersMoviesQueries>();
            services.AddTransient<IUsersQueries, UsersQueries>();
            services.AddTransient<ISendGrid,SendGridUtil>();

            //services.AddTransient<IGenresService, GenresService>();


            services.AddCors(c => c.AddDefaultPolicy(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));


            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Alkemy Challenge");
            });
        }
    }
}
