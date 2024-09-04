namespace Notebook.Domain.Enum
{
    public enum ErrorCodes
    {
        ReportsNotFound = 0,
        ReportNotFound = 1,
        ReportAlreadyExists =2,
        
        UserNotFound = 11,
        UserAlreadyExists = 12,
        PasswordIsWrong = 13,
        
        InternalServerError = 10,
        
        PasswordNotEqualsPasswordConfirm = 21
    }
}