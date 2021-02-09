using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace LAB2_ELENA_V4
{
    class V4DataCollection : V4Data, IEnumerable<DataItem>
    {
        public Dictionary<Vector2, Complex> Dict { set; get; }

        public V4DataCollection(string Info, double Friqency) : base(Info, Friqency) { Dict = new Dictionary<Vector2, Complex>(); }

        public override Complex[] NearMax(float eps) // Done
        {
            Complex max = new Complex(0, 0);
            foreach (Complex item in Dict.Values)
            {
                if (Complex.Abs(item) > Complex.Abs(max))
                {
                    max = item;
                }
            }

            // Находим значения меньше max не более чем на eps
            List<Complex> result = new List<Complex>();
            foreach (Complex item in Dict.Values)
            {
                if (Complex.Abs(max) - Complex.Abs(item) < Math.Abs(eps))
                {
                    result.Add(item);
                }
            }

            return result.ToArray();
        }

        public void InitRandom(int nItems, float xmax, float ymax, double minValue, double maxValue) // Done
        {
            for (int i = 0; i < nItems; i++)
            {
                Random rand = new Random();
                float x_rand = (float)rand.NextDouble() * xmax;
                float y_rand = (float)rand.NextDouble() * ymax;
                Complex value = new Complex(
                            rand.NextDouble() * (maxValue - minValue) + minValue,
                            rand.NextDouble() * (maxValue - minValue) + minValue);
                Vector2 vector = new Vector2(x_rand, y_rand);
                Dict.Add(vector, value);
                System.Threading.Thread.Sleep(100);
            }
        }

        public override string ToLongString() // Done
        {
            string st = "Dictionary values:\n";
            foreach (KeyValuePair<Vector2, Complex> keyValue in Dict)
            {
                st += keyValue.Key + " -> " + keyValue.Value + "\n";
            }
            return ToString() + " " + st;
        }

        public override string ToLongString(string format)
        {
            string st = "Dictionary values:\n";
            foreach (KeyValuePair<Vector2, Complex> keyValue in Dict)
            {
                st += keyValue.Key.ToString(format) + " -> " + keyValue.Value.ToString(format) + "\n";
            }
            return ToString() + " " + st;
        }

        public override string ToString() 
        {
            return $"Object Class: {GetType()}{base.ToString()}Elements in Dictionary:{Dict.Count}";
        }

        public override IEnumerator<DataItem> GetEnumerator()
        {
            List<DataItem> list = new List<DataItem>();
            foreach (KeyValuePair<Vector2, Complex> pair in Dict)
            {
                list.Add(new DataItem(pair.Key, pair.Value));
            }
            return list.GetEnumerator();
        }    
    }
}
