using System.Threading.Tasks;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notebook.Domain.Dto.Report;
using Notebook.Domain.Entity;
using Notebook.Domain.Interfaces.Services;
using Notebook.Domain.Result;

namespace Notebook.Api.Controller
{
    //[Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        /// <summary>
        /// Получение отчета пользователя
        /// </summary>
        /// <param name="dto"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET
        ///     {
        ///         "userId": "1"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Отчеты найдены</response>
        /// <response code="400">Отчет не найдены</response>
        [HttpGet("reports/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<ReportDto>>> GetReports(long userId)
        {
            var response = await _reportService.GetReportsAsync(userId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
        
        /// <summary>
        /// Получение отчета с указанием идентификатора
        /// </summary>
        /// <param name="dto"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET
        ///     {
        ///         "id": "1"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Отчет найден</response>
        /// <response code="400">Отчет не найден</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<ReportDto>>> GetReport(long id)
        {
            var response = await _reportService.GetReportByIdAsync(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
        
        /// <summary>
        /// Удаление отчета с указанием идентификатора
        /// </summary>
        /// <param name="dto"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE
        ///     {
        ///         "id": "1"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Отчет удален</response>
        /// <response code="400">Отчет не удален</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<ReportDto>>> Delete(long id)
        {
            var response = await _reportService.DeleteReportAsync(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
        
        /// <summary>
        /// Создание отчета
        /// </summary>
        /// <param name="dto"></param>
        /// <remarks>
        /// Request for create report:
        /// 
        ///     POST
        ///     {
        ///         "name": "Report #1",
        ///         "description": "Test report",
        ///         "userId": 1
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Отчет создан</response>
        /// <response code="400">Отчет не создан</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<ReportDto>>> Create([FromBody] CreateReportDto dto)
        {
            var response = await _reportService.CreateReportAsync(dto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
        
        /// <summary>
        /// Обновление отчета с указанием основных свойств
        /// </summary>
        /// <param name="dto"></param>
        /// <remarks>
        /// Request for create report:
        /// 
        ///     PUT
        ///     {
        ///         "id": 1,
        ///         "name": "Report #2",
        ///         "description": "Test report2"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Отчет обновлен</response>
        /// <response code="400">Отчет не обновлен</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<ReportDto>>> Update([FromBody] UpdateReportDto dto)
        {
            var response = await _reportService.UpdateReportAsync(dto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}