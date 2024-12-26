// Формальное определение паттерна на языке C# может выглядеть следующим образом:

public interface IStrategy
{
    void Algorithm();
}
 
public class ConcreteStrategy1 : IStrategy
{
    public void Algorithm()
    {}
}
 
public class ConcreteStrategy2 : IStrategy
{
    public void Algorithm()
    {}
}
 
public class Context
{
    public IStrategy ContextStrategy { get; set; }
 
    public Context(IStrategy _strategy)
    {
        ContextStrategy = _strategy;
    }
 
    public void ExecuteAlgorithm()
    {
        ContextStrategy.Algorithm();
    }
}



// Формальное определение на языке C#:

class Client
{
    void Main()
    {
        Handler h1 = new ConcreteHandler1();
        Handler h2 = new ConcreteHandler2();
        h1.Successor = h2;
        h1.HandleRequest(2);
    }
}
abstract class Handler
{
    public Handler Successor { get; set; }
    public abstract void HandleRequest(int condition);
}
 
class ConcreteHandler1 : Handler
{
    public override void HandleRequest(int condition)
    {
        // некоторая обработка запроса
         
        if (condition==1)
        {
            // завершение выполнения запроса;
        }
        // передача запроса дальше по цепи при наличии в ней обработчиков
        else if (Successor != null)
        {
            Successor.HandleRequest(condition);
        }
    }
}
 
class ConcreteHandler2 : Handler
{
    public override void HandleRequest(int condition)
    {
        // некоторая обработка запроса
         
        if (condition==2)
        {
            // завершение выполнения запроса;
        }
        // передача запроса дальше по цепи при наличии в ней обработчиков
        else if (Successor != null)
        {
            Successor.HandleRequest(condition);
        }
    }
}

// Формальное определение паттерна на C# может выглядеть следующим образом:

class Client
{
    public void Main()
    {
        Aggregate a = new ConcreteAggregate();
             
        Iterator i = a.CreateIterator();
 
        object item = i.First();
        while (!i.IsDone())
        {
            item = i.Next();
        }
    }
}
 
abstract class Aggregate
{
    public abstract Iterator CreateIterator();
    public abstract int Count { get; protected set; }
    public abstract object this[int index] { get; set; }
}
  
class ConcreteAggregate : Aggregate
{
    private readonly ArrayList _items = new ArrayList();
  
    public override Iterator CreateIterator()
    {
        return new ConcreteIterator(this);
    }
  
    public override int Count
    {
        get { return _items.Count; }
        protected set { }
    }
 
    public override object this[int index]
    {
        get { return _items[index]; }
        set { _items.Insert(index, value); }
    }
}
abstract class Iterator
{
    public abstract object First();
    public abstract object Next();
    public abstract bool IsDone();
    public abstract object CurrentItem();
}
  
class ConcreteIterator : Iterator
{
    private readonly Aggregate _aggregate;
    private int _current;
  
    public ConcreteIterator(Aggregate aggregate)
    {
        this._aggregate = aggregate;
    }
  
    public override object First()
    {
        return _aggregate[0];
    }
  
    public override object Next()
    {
        object ret = null;
  
        _current++;
  
        if (_current < _aggregate.Count)
        {
            ret = _aggregate[_current];
        }
  
        return ret;
    }
  
    public override object CurrentItem()
    {
        return _aggregate[_current];
    }
  
    public override bool IsDone()
    {
        return _current >= _aggregate.Count;
    }
}
