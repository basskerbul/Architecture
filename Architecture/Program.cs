/*  Закончить разработку паттерна Фабричный метод */

using System.CodeDom.Compiler;
using System.Net;
using System.Transactions;

// Проверка фабричного метода
WeaponFactory.generateWeapon(TypeWeapon.sword);
WeaponFactory.generateWeapon(TypeWeapon.bow);
WeaponFactory.generateWeapon(TypeWeapon.axe);


enum TypeWeapon
{
    sword, bow, axe
}

abstract class Weapon // класс-лекало
{
    private TypeWeapon weapon;
    private int damage;

    abstract public void generate();
}

// дочерние классы
class Sword : Weapon
{
    private TypeWeapon weapon = TypeWeapon.sword;
    private int damage = 10;

    public override void generate()
    {
        Console.WriteLine("Создание меча");
    }
}
class Bow : Weapon
{
    private TypeWeapon weapon;
    private int damage = 9;

    public override void generate()
    {
        Console.WriteLine("Создание лука");
    }

}
class Axe : Weapon
{
    private TypeWeapon weapon;
    private int damage = 8;

    public override void generate()
    {
        Console.WriteLine("Создание топора");
    }
}

// фабрика
class WeaponFactory
{
    public static Weapon generateWeapon(TypeWeapon Tweapon)
    {
        Weapon weapon = null;
        switch (Tweapon)
        {
            case TypeWeapon.sword:
                weapon = new Sword();
                break;
            case TypeWeapon.bow:
                weapon = new Bow();
                break;
            case TypeWeapon.axe:
                weapon = new Axe();
                break;
            default:
                throw new Exception("Не существует такого оружия");
        }
        return weapon;
    }
}