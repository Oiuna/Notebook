namespace Notebook.Domain.Dto.Report
{
    // Для возврата пользователю
    public record ReportDto(long Id, string Title, string Description, string DateCreated);
}