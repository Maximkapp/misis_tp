using System;

public abstract class GameObject {
    private int id;
    private string name;
    private int x;
    private int y;

    public GameObject(int id, string name, int x, int y) {
        this.id = id;
        this.name = name;
        this.x = x;
        this.y = y;
    } 

    public int GetId() => id;
    public string GetName() => name;
    public int GetX() => x;
    public int GetY() => y;
}

public abstract class Unit : GameObject {
    private float hp;

    public Unit(int id, string name, int x, int y, float hp) : base (id, name, x, y){
        this.hp = hp;
    }

    public bool IsAlive() => hp > 0;
    public float GetHp() => hp;

    public void ReceiveDamage(float damage) {
        hp -= damage;
        if (hp < 0) hp = 0;
    }
}

public abstract class Building : GameObject {
    
    private bool isBuilt;

    public Building(int id, string name, int x, int y, bool isBuilt) : base(id, name, x, y) {
        this.isBuilt = isBuilt;
    }

    public bool IsBuilt() => isBuilt;
}

public interface IAttacker {
    void Attack(Unit unit);
}

public interface IMoveable {
    void Move(int newX, int newY);
}

public class Archer : Unit, IAttacker, IMoveable
{
    public Archer(int id, string name, int x, int y, float hp) : base(id, name, x, y, hp) { }

    public void Attack(Unit unit)
    {
        if (unit.IsAlive())
        {
            unit.ReceiveDamage(10); // Условно наносим 10 урона
            Console.WriteLine($"{GetName()} атакует {unit.GetName()} и наносит 10 урона.");
        }
    }

    public void Move(int newX, int newY)
    {
        Console.WriteLine($"{GetName()} перемещается с ({GetX()}, {GetY()}) на ({newX}, {newY})");
    }
}

public class Fort : Building, IAttacker
{
    public Fort(int id, string name, int x, int y, bool isBuilt) : base(id, name, x, y, isBuilt) { }

    public void Attack(Unit unit)
    {
        if (unit.IsAlive())
        {
            unit.ReceiveDamage(20); // Условно наносим 20 урона
            Console.WriteLine($"{GetName()} атакует {unit.GetName()} и наносит 20 урона.");
        }
    }
}

public class MobileHouse : Building, IMoveable
{
    public MobileHouse(int id, string name, int x, int y, bool isBuilt) : base(id, name, x, y, isBuilt) { }

    public void Move(int newX, int newY)
    {
        Console.WriteLine($"{GetName()} перемещается с ({GetX()}, {GetY()}) на ({newX}, {newY})");
    }
}

public class Program
{
    public static void Main()
    {
        Archer archer1 = new Archer(1, "Лучник1", 0, 0, 100);
        Archer archer2 = new Archer(2, "Лучник2", 0, 0, 100);
        Fort fort = new Fort(2, "Крепость", 10, 10, true);
        MobileHouse mobileHouse = new MobileHouse(3, "Дом на колесах", 5, 5, true);

        archer1.Attack(archer2); // Демонстрация атаки
        fort.Attack(archer1); // Крепость атакует лучника
        mobileHouse.Move(7, 7); // Перемещение дома на колесах
    }
}
