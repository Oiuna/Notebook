namespace Notebook.Domain.Interfaces
{
    //интерфейс позволяет создать разные типы id - short, int, long в зависимости от сущности, в котором будет использоваться
    //id  может быть только value type(не строка и объект)
    public interface IEntityId<T> where T : struct 
    {
        public T Id { get; set; }
    }
}