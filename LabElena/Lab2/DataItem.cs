using System.Numerics;

namespace LAB2_ELENA_V4
{
    public struct DataItem
    {
        public DataItem(Vector2 point, Complex n)
        {
            Point = point;
            N = n;
        }

        /// <summary>
        /// Координаты двумерной точки
        /// </summary>
        public Vector2 Point { get; }

        /// <summary>
        /// Комплексное значение электромагнитного поля
        /// </summary>
        public Complex N { get; }

        public override string ToString()
        {
            return $"DataItem: Point = ({Point.X}, {Point.Y}), N = {N.Real} + {N.Imaginary}i";
        }

        public string ToString(string format)
        {
            return $"DataItem: Point = {Point.ToString(format)}, N = {N.ToString(format)}";
        }
    }
}
