/*  Закончить разработку паттерна Фабричный метод */

using System.CodeDom.Compiler;
using System.Transactions;

// Проверка фабричного метода
FigureFactory.generateFigure(FigureType.trigale);
FigureFactory.generateFigure(FigureType.sqare);
FigureFactory.generateFigure(FigureType.circle);


enum FigureType //типы фигур
{
    trigale, sqare, circle 
}

abstract class Figure // класс-лекало
{
    private FigureType type;

    abstract public void generate();
}

// дочерние классы
class Trigale : Figure
{
    private FigureType fType = FigureType.trigale;

    public override void generate()
    {
        Console.WriteLine("Создание треугольника");
    }
}
class Sqare : Figure
{
    private FigureType type;

    public override void generate()
    {
        Console.WriteLine("Создание квадрата");
    }

}
class Circle : Figure
{
    private FigureType type;

    public override void generate()
    {
        Console.WriteLine("Создание круга");
    }
}

// фабрика
class FigureFactory
{
    public static Figure generateFigure(FigureType fType)
    {
        Figure figure = null;
        switch (fType)
        {
            case FigureType.trigale:
                figure = new Trigale();
                break;
            case FigureType.sqare:
                figure = new Sqare();
                break;
            case FigureType.circle:
                figure = new Circle();
                break;
            default:
                throw new Exception("Не существует такой фигуры");
        }
        return figure;
    }
}


