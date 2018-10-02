namespace FundamentCore.Interface
{
    public interface IQueue<T>
    {
        void Enqueue(T t);
        T Front();
        T Dequeue();
        bool IsEmpty();
        int Count();
    }
}
