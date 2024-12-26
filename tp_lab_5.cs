// На C# паттерн формально может выглядеть следующим образом:
class Client
{
    void Main()
    {
        Subject subject = new Proxy();
        subject.Request();
    }
}
abstract class Subject
{
    public abstract void Request();
}
 
class RealSubject : Subject
{
    public override void Request()
    {}
}
class Proxy : Subject
{
    RealSubject realSubject;
    public override void Request()
    {
        if (realSubject == null)
            realSubject = new RealSubject();
        realSubject.Request();
    }
}

// Формальное описание паттерна на языке C#:

class Client
{
    static void Main()
    {
        Abstraction abstraction;
        abstraction = new RefinedAbstraction(new ConcreteImplementorA());
        abstraction.Operation();
        abstraction.Implementor=new ConcreteImplementorB();
        abstraction.Operation();
    }
}
abstract class Abstraction
{
    protected Implementor implementor;
    public Implementor Implementor
    {
        set { implementor = value; }
    }
    public Abstraction(Implementor imp)
    {
        implementor = imp;
    }
    public virtual void Operation()
    {
        implementor.OperationImp();
    }
}
 
abstract class Implementor
{
    public abstract void OperationImp();
}
 
class RefinedAbstraction : Abstraction
{
    public RefinedAbstraction(Implementor imp)
        : base(imp)
    {}
    public override void Operation()
    {
    }
}
 
class ConcreteImplementorA : Implementor
{
    public override void OperationImp()
    {
    }
}
 
class ConcreteImplementorB : Implementor
{
    public override void OperationImp()
    {
    }
}

// Формальное описание адаптера объектов на C# выглядит таким образом:

class Client
{
    public void Request(Target target)
    {
        target.Request();
    }
}
// класс, к которому надо адаптировать другой класс   
class Target
{
    public virtual void Request()
    {}
}
  
// Адаптер
class Adapter : Target
{
    private Adaptee adaptee = new Adaptee();
  
    public override void Request()
    {
        adaptee.SpecificRequest();
    }
}
  
// Адаптируемый класс
class Adaptee
{
    public void SpecificRequest()
    {}
}
