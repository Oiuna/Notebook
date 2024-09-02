using System.Threading.Tasks;
using Notebook.Domain.Dto;
using Notebook.Domain.Dto.Report;
using Notebook.Domain.Entity;
using Notebook.Domain.Result;

namespace Notebook.Domain.Interfaces.Services
{
    /// <summary>
    /// Сервис отвечающий за работу с доменной части отчета
    /// </summary>
    public interface IReportService
    {
        /// <summary>
        /// Получние всех отчетов пользоввателя
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<CollectionResult<ReportDto>> GetReportsAsync(long userId);

        /// <summary>
        /// Получение отчета по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BaseResult<ReportDto>> GetReportByIdAsync(long id);
        
        /// <summary>
        /// Создание отчета с базовыми параметрами
        /// </summary>
        /// <returns></returns>
        Task<BaseResult<ReportDto>> CreateReportAsync(CreateReportDto dto);

        /// <summary>
        /// Удаление отчета по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BaseResult<ReportDto>> DeleteReportAsync(long id);
        
        /// <summary>
        /// Обновление отчета отчета
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BaseResult<ReportDto>> UpdateReportAsync(UpdateReportDto dto);
    }
}