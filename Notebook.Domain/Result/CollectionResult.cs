using System.Collections.Generic;

namespace Notebook.Domain.Result
{
    public class CollectionResult<T> : BaseResult<IEnumerable<T>> // Возвращает коллекцию ответов
    {
        public int Count { get; set; }
    }
}