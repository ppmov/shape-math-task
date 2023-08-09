namespace GeometryTest
{
    public class Tests
    {
        [TestCase(5d, Math.PI * 25d, TestOf = typeof(Circle))]
        public void CircleArea(double radius, double expected)
        {
            var circle = new Circle(radius);
            Assert.That(circle.GetArea(), Is.EqualTo(expected));
        }

        [TestCase(3, 4, 5, 6, TestOf = typeof(Triangle))]
        public void TriangleArea(double a, double b, double c, double expected)
        {
            var circle = new Triangle(a, b, c);
            Assert.That(circle.GetArea(), Is.EqualTo(expected));
        }

        [TestCase(1, 2, 2, false, TestOf = typeof(Triangle))]
        public void RightTriangle(double a, double b, double c, bool expected)
        {
            var circle = new Triangle(a, b, c);
            Assert.That(circle.HasRightAngle(), Is.EqualTo(expected));
        }
    }
}