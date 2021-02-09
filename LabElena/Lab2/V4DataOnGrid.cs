using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace LAB2_ELENA_V4
{
    class V4DataOnGrid : V4Data, IEnumerable<DataItem>
    {
        public Grid2D Grid { set; get; }
        public Complex[,] ValuesOnGrid { set; get; }

        public V4DataOnGrid(string Info, double Friqency, Grid2D Grid) : base(Info, Friqency)
        {
            this.Grid = Grid;
            ValuesOnGrid = new Complex[Grid.CountX, Grid.CountY];
        }

        private V4DataOnGrid(StreamReader reader) : base(reader)
        {
            try
            {
                try
                {
                    float Dx = float.Parse(reader.ReadLine());
                    int CountX = int.Parse(reader.ReadLine());
                    float Dy = float.Parse(reader.ReadLine());
                    int CountY = int.Parse(reader.ReadLine());
                    Grid = new Grid2D(Dx, CountX, Dy, CountY);
                    ValuesOnGrid = new Complex[Grid.CountX, Grid.CountY];
                }
                catch (ArgumentNullException)
                {

                    Console.WriteLine("Строковое представление числоа имеет значение null.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Строковое представление имеет неправильный формат.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Строковое представления представляет число, которое меньше значения MinValue или больше значения MaxValue.");
                }

            }
            catch (IOException)
            {
                Console.WriteLine("Ошибка ввода-вывода.");
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Не хватает памяти для выделения буфера под возвращаемую строку.");
            }
            catch (ObjectDisposedException)
            {
                Console.WriteLine("Объект TextReader закрыт.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Количество символов в строке больше MaxValue.");
            }
        }

        /// <summary>
        /// Инициализирует объект данными из файла <c>fileName</c>
        /// Формат файла - на одной строе одно строкове значение:
        /// Info
        /// Frequency
        /// Dx
        /// CountX
        /// Dy
        /// CiuntY
        /// </summary>
        /// <param name="fileName"></param>
        public V4DataOnGrid(string fileName) : this(File.OpenText(fileName))
        {
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
                    System.Threading.Thread.Sleep(5);
                }
            }
        }

        public static explicit operator V4DataCollection(V4DataOnGrid val) //TODO
        {
            V4DataCollection result = new V4DataCollection(val.Info, val.Frequency);
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

        public override string ToLongString(string format)
        {
            string st = "Grid values:\n";
            for (int i = 0; i < Grid.CountX; i++)
            {
                for (int j = 0; j < Grid.CountY; j++)
                {
                    st += string.Format("<{0},{1}> -> ({2}, {3})    ", i, j, Math.Round(ValuesOnGrid[i, j].Real, 2).ToString(format), Math.Round(ValuesOnGrid[i, j].Imaginary, 2).ToString(format));
                }
                st += "\n";
            }
            return string.Format(ToString() + " " + st);
        }


        public override string ToString()
        {
            return string.Format("Object Class: {0}; {1} {2}", GetType(), base.ToString(), Grid);
        }

        public override IEnumerator<DataItem> GetEnumerator()
        {
            List<DataItem> list = new List<DataItem>();
            for(int x = 0; x < Grid.CountX; x++)
            {
                for(int y = 0; y < Grid.CountY; y++)
                {
                    DataItem data = new DataItem(new Vector2(Grid.Dx*x, Grid.Dy*y), ValuesOnGrid[x, y]); 
                    list.Add(data);
                }
            }
            return list.GetEnumerator();
        }
    }
}
