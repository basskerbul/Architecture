/* Написать любом языке программирования, в которой идёт со следующими геометрическими фигурами:
1.Треугольник
2.Квадрат
3.Прямоугольник.
4.Круг
В программе имеется массив фигур, с которым можно сделать следующие операции:
1.Добавить новую фигуру
2. Посчитать периметр у всех фигур
3. Посчитать площадь у всех фигур
Для фигуры использовать базовый абстрактный класс фигуры, у которого есть методы посчитать периметр и посчитать площадь фигуры. 
Массив фигур в программе должен быть представлен как массив объектов этого базового класса. Массив фигур должен создаваться и вся работа 
с ним идёт внутри main. При создании фигур необходимо осуществлять проверку входных данных на возможность создания данной фигуры и в
случае ошибки выдавать соответствующие сообщения. */
using System.Drawing;

Figure f1 = AddShape(ShapeType.TRIANGLE);
Figure f2 = AddShape(ShapeType.CIRCLE);
Figure f3 = AddShape(ShapeType.RECTANGLE);
Figure f4 = AddShape(ShapeType.SQUARE);
Figure[] figures = { f1, f2, f3, f4};

for(int i = 0; i < figures.Length; i++)
{
    PrintInfo(figures[i]);
}

Figure AddShape(ShapeType Stype)
{
    Figure figure = null;
    switch (Stype)
    {
        case ShapeType.TRIANGLE:
            Console.WriteLine("Создание треугольника \nВведите длинну первого катета");
            int sideA = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение второго катета");
            int sideB = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение высоты треугольника");
            int height = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение основния");
            int footing = int.Parse(Console.ReadLine());
            figure = new Triangle(sideA, sideB, height, footing);
            break;
        case ShapeType.SQUARE:
            Console.WriteLine("Создание квадрата \nВведите длинну стороны");
            int side = int.Parse(Console.ReadLine());
            figure = new Square(side);
            break;
        case ShapeType.RECTANGLE:
            Console.WriteLine("Создание прямоугольника \nВведите ширину");
            int SideA = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите высоту");
            int SideB = int.Parse(Console.ReadLine());
            figure = new Rectangle(SideA, SideB);
            break;
        case ShapeType.CIRCLE:
            Console.WriteLine("Создание круга \nВведите радиус");
            int radius = int.Parse(Console.ReadLine());
            figure = new Circle(radius);
            break;
        default:
            throw new ArgumentException("Недопустимый тип");
    }
    return figure;
}

void PrintInfo(Figure figure)
{
    Console.WriteLine($"Площадь фигуры: {figure.CalculateArea()}");
    if(figure is ICalculatePerimeter)
        Console.WriteLine($"Периметр фигуры: {((ICalculatePerimeter)figure).CalculatePerimeter()}");
    
    if (figure is ICircumferenceLength)
        Console.WriteLine($"Длина окружности: {((ICircumferenceLength)figure).CircumferenceLength()}");
}

enum ShapeType { TRIANGLE, SQUARE, RECTANGLE, CIRCLE }

interface ICalculatePerimeter
{
    public int CalculatePerimeter();
}
interface ICircumferenceLength
{
    public float CircumferenceLength();
}

abstract class Figure {
 
    abstract public int CalculateArea();
}

class Triangle : Figure, ICalculatePerimeter {

    private int sideA;
    private int sideB;
    private int height;
    private int footing;

    public Triangle(int sideA, int sideB, int height, int footing)
    {
        if (sideA <= 0)
            throw new ArgumentException("Значение не может быть меньше 0");
        else
            this.sideA = sideA;

        if (sideB <= 0)
            throw new ArgumentException("Значение не может быть меньше 0");
        else
            this.sideB = sideB;

        if (height <= 0)
            throw new ArgumentException("Значение не может быть меньше 0");
        else
            this.height = height;

        if (footing <= 0)
            throw new ArgumentException("Значение не может быть меньше 0");
        else
            this.footing = footing;
    }

    public override int CalculateArea()
    {
        return height * footing / 2;
    }
    public int CalculatePerimeter()
    {
        return sideA + sideB + footing;
    }
}
class Square : Figure, ICalculatePerimeter {

    private int side;

    public Square(int side)
    {
        if (side <= 0)
            throw new ArgumentException("Значение не может быть меньше 0");
        else
            this.side = side;
    }

    public override int CalculateArea()
    {
        return side * side;
    }
    public int CalculatePerimeter()
    {
        return side * 4;
    }
}
class Rectangle : Figure, ICalculatePerimeter
{
    private int sideA;
    private int sideB;

    public Rectangle(int sideA, int sideB)
    {
        if (sideA <= 0)
            throw new ArgumentException("Значение не может быть меньше 0");
        else
            this.sideA = sideA;

        if (sideB <= 0)
            throw new ArgumentException("Значение не может быть меньше 0");
        else
            this.sideB = sideB;
    }

    public override int CalculateArea()
    {
        return sideA * sideB;
    }
    public int CalculatePerimeter()
    {
        return (sideA * 2) + (sideB * 2);
    }
}
class Circle : Figure, ICircumferenceLength
{
    private double pi = 3.14;
    private int radius;

    public Circle(int radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Значение не может быть меньше 0");
        else
            this.radius = radius;
    }
    public override int CalculateArea()
    {
        return (int)((radius * radius) * pi);
    }
    public float CircumferenceLength()
    {
        return (float)(2 * pi * radius);
    }
}