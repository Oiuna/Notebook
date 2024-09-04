using FluentValidation;
using Microsoft.EntityFrameworkCore.Update;
using Notebook.Domain.Dto.Report;

namespace Notebook.Application.Validations.FluentValidations.Report
{
    public class UpdateReportValidator : AbstractValidator<UpdateReportDto>
    {
        public UpdateReportValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(1000);
        }
    }
}