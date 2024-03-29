using AdvanceProject.Bll.Abstract;
using AdvanceProject.Bll.Concrete;
using AdvanceProject.Bll.Mapper;
using AdvanceProject.Dal.Helper;
using AdvanceProject.Dal.UnitofWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace AdvanceProject.API
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
            ConnectionHelper.SetConfiguration(Configuration);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AdvanceProject.API", Version = "v1" });
            });


            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthManager, AuthManager>();
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<IBusinessUnitManager, BusinessUnitManager>();
            services.AddScoped<ITitleManager, TitleManager>();
            services.AddScoped<IAdvanceManager, AdvanceManager>();
            services.AddScoped<IProjectManager, ProjectManager>();
            services.AddScoped<MyMapper>();
            
            var apiSecretKey = Encoding.ASCII.GetBytes(Configuration.GetSection("apisecretkey").Value);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(apiSecretKey),
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidAudience = "BilgeAdam",
                    ValidIssuer = "Semih"
                };
            });

            services.AddAuthorization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdvanceProject.API v1"));
            }
            
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
