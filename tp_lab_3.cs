// одиночка
class Singleton
{
    private static Singleton instance;
 
    private Singleton()
    {}
 
    public static Singleton getInstance()
    {
        if (instance == null)
            instance = new Singleton();
        return instance;
    }
}


// фабричный
abstract class Product
{}
 
class ConcreteProductA : Product
{}
 
class ConcreteProductB : Product
{}
 
abstract class Creator
{
    public abstract Product FactoryMethod();
}
 
class ConcreteCreatorA : Creator
{
    public override Product FactoryMethod() { return new ConcreteProductA(); }
}
 
class ConcreteCreatorB : Creator
{
    public override Product FactoryMethod() { return new ConcreteProductB(); }


//абстрактная фабрика
public interface IProductA
{
    string GetName();
}

public interface IProductB
{
    string GetName();
}

public class ProductA1 : IProductA
{
    public string GetName() => "Product A1";
}

public class ProductB1 : IProductB
{
    public string GetName() => "Product B1";
}

public class ProductA2 : IProductA
{
    public string GetName() => "Product A2";
}

public class ProductB2 : IProductB
{
    public string GetName() => "Product B2";
}

public interface IAbstractFactory
{
    IProductA CreateProductA();
    IProductB CreateProductB();
}

public class ConcreteFactory1 : IAbstractFactory
{
    public IProductA CreateProductA() => new ProductA1();
    public IProductB CreateProductB() => new ProductB1();
}

public class ConcreteFactory2 : IAbstractFactory
{
    public IProductA CreateProductA() => new ProductA2();
    public IProductB CreateProductB() => new ProductB2();
}

// строитель
public class Product
{
    public string PartA { get; set; }
    public string PartB { get; set; }
}

public interface IBuilder
{
    void BuildPartA();
    void BuildPartB();
    Product GetResult();
}

public class ConcreteBuilder : IBuilder
{
    private Product _product = new Product();

    public void BuildPartA() => _product.PartA = "Part A";
    public void BuildPartB() => _product.PartB = "Part B";

    public Product GetResult() => _product;
}

public class Director
{
    private IBuilder _builder;

    public Director(IBuilder builder)
    {
        _builder = builder;
    }

    public void Construct()
    {
        _builder.BuildPartA();
        _builder.BuildPartB();
    }
}
