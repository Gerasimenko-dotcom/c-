using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace LAB2_ELENA_V4
{
    class V4MainCollection : IEnumerable
    {
        private List<V4Data> list;

        public V4MainCollection()
        {
            this.list = new List<V4Data>();
        }
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable<V4Data>)list).GetEnumerator();
        }

        public int Count //Done
        {
            get
            {
                return list.Count;
            }
        }

        public void Add(V4Data item) // Done
        {
            list.Add(item);
        }

        public bool Remove(string id, double w)
        {
            bool flag = true;
            foreach (V4Data item in list)
            {
                if (item.Frequency == w && item.Info == id)
                {
                    list.Remove(item);
                    flag = false;
                }
            }
            return flag;
        }

        public void AddDefaults() // Можно изменить параметр на случайные
        {

            V4DataCollection v1 = new V4DataCollection("Test1-0", 50);
            v1.InitRandom(30, 5, 5, 0, 100);

            V4DataCollection v2 = new V4DataCollection("Test1-1", 50);
            v2.InitRandom(0, 5, 5, 0, 100);

            V4DataOnGrid v3 = new V4DataOnGrid("Test2-0", 60, new Grid2D((float)0.5, 10, (float)0.5, 10));
            v3.InitRandom(10, 200);

            V4DataOnGrid v4 = new V4DataOnGrid("Test2-1", 70, new Grid2D((float)1.1, 0, (float)1.1, 0));
            v4.InitRandom(10, 200);

            Add(v1);
            Add(v2);
            Add(v3);
            Add(v4);

        }

        public override string ToString() // Done
        {
            string st = "";
            foreach (V4Data item in list)
            {
                st += item.ToString() + "\n";
            }
            return st;
        }


        public string ToLongString(string format)
        {
            string st = "";
            foreach (V4Data item in list)
            {
                st += item.ToLongString(format) + "\n";
            }
            return st;
        }


        public double Avg
        {
            get
            {
                return list.Average(item => Math.Abs(item.Frequency));
            }
        }

        public IEnumerable<DataItem> NearZero(float R)
        {
            List<DataItem> dataItems = new List<DataItem>();
            list.ForEach(data => dataItems.AddRange(data));
            return dataItems.Where(item => item.Point.Length() <= R);
        }

        public IEnumerable<Vector2> OnlyOne
        {
            get
            {
                List<DataItem> dataItems = new List<DataItem>();
                list.OfType<V4DataCollection>().ToList().ForEach(data => dataItems.AddRange(data));
                var query = dataItems.GroupBy(item => item.Point, item => item.N, (point, N) => new
                {
                    Point = point,
                    Count = N.Count()
                });
                return query.Where(item => item.Count == 1).Select(item => item.Point);
            }
        }
    }
}
