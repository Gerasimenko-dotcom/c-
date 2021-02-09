using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LAB1_ELENA_V4
{
    class V4DataOnGrid : V4Data
    {
        public Grid2D Grid { set; get; }
        public Complex[,] ValuesOnGrid { set; get; }

        public V4DataOnGrid(string Info, double Friqency, Grid2D Grid) : base(Info, Friqency)
        {
            this.Grid = Grid;
            ValuesOnGrid = new Complex[Grid.CountX, Grid.CountY];
        }

        public void InitRandom(double minValue, double maxValue) // Done
        {
            Random rand = new Random();
            for (int i = 0; i < Grid.CountX; i++)
            {
                for (int j = 0; j < Grid.CountY; j++)
                {
                    ValuesOnGrid[i, j] = new Complex(
                            rand.NextDouble() * (maxValue - minValue) + minValue,
                            rand.NextDouble() * (maxValue - minValue) + minValue);
                }
            }
        }

        public static explicit operator V4DataCollection(V4DataOnGrid val) //TODO
        {
            V4DataCollection result = new V4DataCollection(val.Info, val.Friqency);
            for (int i = 0; i < val.Grid.CountX; i++)
            {
                for (int j = 0; j < val.Grid.CountY; j++)
                {
                    result.Dict.Add(new Vector2(i, j), val.ValuesOnGrid[i, j]);
                }
            }
            return result;
        }

        public override Complex[] NearMax(float eps) // Done
        {

            Complex max = new Complex(0, 0);
            for (int i = 0; i < Grid.CountX; i++)
            {
                for (int j = 0; j < Grid.CountY; j++)
                {
                    if (Complex.Abs(ValuesOnGrid[i, j]) >= Complex.Abs(max))
                    {
                        max = ValuesOnGrid[i, j];
                    }
                }

            }
            // Находим значения меньше max не более чем на eps
            List<Complex> result = new List<Complex>();
            for (int i = 0; i < Grid.CountX; i++)
            {
                for (int j = 0; j < Grid.CountY; j++)
                {
                    if (Complex.Abs(max) - Complex.Abs(ValuesOnGrid[i, j]) <= Math.Abs(eps))
                    {
                        result.Add(ValuesOnGrid[i, j]);
                    }
                }

            }
            return result.ToArray();
        }

        public override string ToLongString() // Done
        {
            string st = "Grid values:\n";
            for (int i = 0; i < Grid.CountX; i++)
            {
                for (int j = 0; j < Grid.CountY; j++)
                {
                    st += String.Format("<{0},{1}> -> ({2}, {3})    ", i, j, Math.Round(ValuesOnGrid[i, j].Real, 2), Math.Round(ValuesOnGrid[i, j].Imaginary, 2));
                }
                st += "\n";
            }
            return String.Format(ToString() + " " + st);
        }

        public override string ToString() // Done
        {
            return String.Format("Object Class: {0}; {1} {2}", GetType(), base.ToString(), Grid);
        }
    }
}
