using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Shapes_6_1
{
    static class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(45, 35, 30);
            Rectangle rectangle = new Rectangle(25, 15);
            Square square = new Square(80);

            Console.ReadKey();
        }
    }

    abstract class Shape
    {
        protected abstract float[] Sides { get; set; }
        protected abstract float Area { get; private protected set; }
        protected abstract float Perimeter { get; private protected set; }

        protected Shape()
        {
        }

        protected abstract void FindArea();
        protected abstract void FindPerimeter();
        protected void Display()
        {
            Console.Write("Sides: ");
            foreach (var side in Sides)
                Console.Write("{0,3}", side);

            Console.WriteLine($"\nArea: {Area}");
            Console.WriteLine($"Perimeter: {Perimeter}");
        }
    }

    sealed class Square : Shape
    {
        private float[] _sides;

        protected override float[] Sides
        {
            get => _sides;
            set
            {
                if (_sides.Any(side => side <= 0))
                    throw new Exception("Shape can\'t have negative sides");

                _sides = value;
            }
        }

        protected override float Area { get; private protected set; }
        protected override float Perimeter { get; private protected set; }

        public Square(float side)
        {
            _sides = new float[4];
            for (int i = 0; i < 4; i++)
                _sides[i] = side;
            FindArea();
            FindPerimeter();
            Display();
        }
        protected sealed override void FindArea()
        {
            Area = (float)Sides[0] * Sides[0];
        }
        protected sealed override void FindPerimeter()
        {
            Perimeter = (float) Sides[0] * 4;
        }
    }

    sealed class Triangle : Shape
    {
        private float[] _sides;

        protected override float[] Sides
        {
            get => _sides;
            set
            {
                if (Sides.Any(side => side <= 0))
                    throw new Exception("Shape can\'t have negative sides");

                _sides = value;
            }
        }

        protected override float Area { get; private protected set; }
        protected override float Perimeter { get; private protected set; }

        public Triangle(float side1, float side2, float side3)
        {
            _sides = new float[3];
            _sides[0] = side1;
            _sides[1] = side2;
            _sides[2] = side3;
            FindPerimeter();
            FindArea();
            Display();
        }
        protected sealed override void FindArea()
        {
            Area = (float) Math.Sqrt(Perimeter / 2 * 
                                      (Perimeter / 2 - Sides[0]) * 
                                      (Perimeter / 2 - Sides[1]) *
                                      (Perimeter / 2 - Sides[2]));
        }
        protected sealed override void FindPerimeter()
        {
            Perimeter = Sides[0] + Sides[1] + Sides[2];
        }

    }
    class Rectangle : Shape
    {
        private float[] _sides;

        protected override float[] Sides
        {
            get => _sides;
            set
            {
                if (Sides.Any(side => side <= 0))
                    throw new Exception("Shape can\'t have negative sides");

                _sides = value;
            }
        }

        protected override float Area { get; private protected set; }
        protected override float Perimeter { get; private protected set; }

        public Rectangle(float height, float weight)
        {
            _sides = new float[4];
            for (int i = 0; i < 2; i++)
            {
                _sides[i] = height;
                _sides[i+2] = weight;
            }
            FindArea();
            FindPerimeter();
            Display();
        }
        protected sealed override void FindArea()
        {
            Area = (float) Sides[0] * Sides[1];
        }
        protected sealed override void FindPerimeter()
        {
            Perimeter = Sides[0] + Sides[1] + Sides[2] + Sides[3];
        }
    }
}
