using FluentValidation;
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

namespace Notebook.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ReportMapping));
            
            InitServices(services);
        }
        
        public static void InitServices(this IServiceCollection services)
        {
            services.AddScoped<IReportValidator, ReportValidator>();
            services.AddScoped<IValidator<CreateReportDto>, CreateReportValidator>();
            services.AddScoped<IValidator<UpdateReportDto>, UpdateReportValidator>();

            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }

}