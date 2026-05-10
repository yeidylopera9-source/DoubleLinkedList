namespace Shared;

public interface ILinkedList<T>
{
    void showForward(T data);

    void showBack(T data);

    void Add(T data);

    void exists(T data);

    void orderDecently(T data);

    void showFashions(T data);

    void showGraph(T data);

    void eliminate(T data, bool all);

    string ToString();
}