using Notebook.Domain.Entity;
using Notebook.Domain.Result;

namespace Notebook.Domain.Interfaces.Validations
{
    public interface IReportValidator : IBaseValidator<Report>
    {
        /// <summary>
        /// Проверка наличия отчета с переданным названием, чтобы избежать создания двух отчетов с одинаковым названием
        /// Проверка наличия пользователя с указанным id
        /// </summary>
        /// <param name="report"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        BaseResult CreateValidator(Report report, User user);
    }
}