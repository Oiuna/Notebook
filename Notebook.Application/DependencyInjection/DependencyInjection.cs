using FluentValidation;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notebook.Application.Mapping;
using Notebook.Application.Services;
using Notebook.Application.Validations;
using Notebook.Application.Validations.FluentValidations;
using Notebook.Application.Validations.FluentValidations.Report;
using Notebook.Domain.Dto;
using Notebook.Domain.Dto.Report;
using Notebook.Domain.Interfaces.Services;
using Notebook.Domain.Interfaces.Validations;
using Notebook.Domain.Settings;

namespace Notebook.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(ReportMapping));

            var options = configuration.GetSection(nameof(RedisSettings));
            var redisUrl = options["Url"];
            var instanceName = options["InstanceName"];

            services.AddStackExchangeRedisCache(redisCacheOptions =>
            {
                redisCacheOptions.Configuration = redisUrl;
                redisCacheOptions.InstanceName = instanceName;
            });
            
            InitServices(services);
        }
        
        public static void InitServices(this IServiceCollection services)
        {
            services.AddScoped<IReportValidator, ReportValidator>();
            services.AddScoped<IValidator<CreateReportDto>, CreateReportValidator>();
            services.AddScoped<IValidator<UpdateReportDto>, UpdateReportValidator>();

            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }

}