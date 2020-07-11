using System;
using System.Collections.Generic;

namespace MathGraph.Data
{
    class EquationSolver
    {
        private readonly double a;
        private readonly double b;
        private double h;
        private double x;
        private double y;
        public List<double> Values;

        public EquationSolver()
        {
            a = -10;
            b = 10;
            Values = new List<double>();
        }
        public void Sinus()
        {
            x = a;
            Values.Clear();
            while (x <= b)
            {
                y = Math.Sin(x);
                Values.Add(y);
                x += h;
            }
        }
        public void Cosinus()
        {
            x = a;
            Values.Clear();
            while (x <= b)
            {
                y = Math.Cos(x);
                Values.Add(y);
                x += h;
            }
        }
        public void Power(int value)
        {
            x = 0;
            Values.Clear();
            while (x <= b)
            {
                y = Math.Pow(x, value);
                Values.Add(y);
                x += h;
            }
        }
        public void SquareRoot()
        {
            x = 0;
            Values.Clear();
            while (x <= b)
            {
                y = Math.Sqrt(x);
                Values.Add(y);
                x += h;
            }
        }
        public void SetStep(double value)
        {
            h = value;
        }
    }
}
