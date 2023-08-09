// По поводу вычисления площади фигуры без знания типа фигуры в compile-time:

// Сама суть времени компиляции заключается в том, что программа заранее знает все типы и все объекты, которые используются в компилируемом коде.
// Если тип фигуры заранее неизвестен, подсчет площади всегда будет проходить в run-time. Поэтому, если я правильно понял задачу, подобная реализация невозможна.

namespace Geometry
{
    public abstract class Shape
    {
        public abstract double GetArea();
    }

    public abstract class Polygon : Shape
    {
        protected readonly double[] _sides;

        public double Perimeter => _sides.Sum();
        public double Semiperimeter => Perimeter / 2f;

        public Polygon(params double[] sides) => _sides = sides;
    }

    public class Circle : Shape
    {
        public readonly double radius;

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("The specified circle cannot exist");

            this.radius = radius;
        }

        public override double GetArea() =>
            Math.PI * radius * radius;
    }

    public class Triangle : Polygon
    {
        public Triangle(double a, double b, double c) : base(a, b, c) 
        {
            if (a >= b + c || b >= a + c || c >= a + b)
                throw new ArgumentException("The specified triangle cannot exist");
        }

        public override double GetArea() =>
            Math.Sqrt(Semiperimeter * _sides.Select(x => Semiperimeter - x).Sum());

        public bool HasRightAngle()
        {
            var sides = _sides.OrderBy(x => x);
            var hypotenuse = _sides.Last();
            var legs = _sides.SkipLast(1);

            return Math.Pow(hypotenuse, 2) == Math.Pow(legs.First(), 2) + Math.Pow(legs.Last(), 2);
        }
    }
}