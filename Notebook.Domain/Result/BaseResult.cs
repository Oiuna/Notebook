using System.Reflection.Emit;
using System.Threading.Tasks;

namespace Notebook.Domain.Result
{
    public class BaseResult // Ответ сервиса
    {
        public bool IsSuccess => ErrorMessage == null;
        public string ErrorMessage { get; set; }
        
        public int? ErrorCode { get; set; }
    }
    
    public class BaseResult<T> : BaseResult // Ответ сервиса для клиента с данными
    {
        public BaseResult(string errorMessage, int errorCode, T data)
        {
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
            Data = data;
        }

        public BaseResult() { }
        public T Data { get; set; }
    }
}