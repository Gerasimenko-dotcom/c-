using System.Collections;
using System.Collections.Generic;

namespace LAB1_ELENA_V4
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
                if (item.Friqency == w && item.Info == id)
                {
                    list.Remove(item);
                    flag = false;
                }
            }
            return flag;
        }

        public void AddDefaults() // Можно изменить параметр на случайные
        {
            for (int i = 0; i < 5; i++)
            {
                V4DataCollection v1 = new V4DataCollection("Test1", 50);
                v1.InitRandom(30, 5, 5, 0, 100);
                V4DataOnGrid v2 = new V4DataOnGrid("Test2", 60, new Grid2D((float)0.5, 10, (float)0.5, 10));
                v2.InitRandom(10, 200);
                Add(v1);
                Add(v2);
            }
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

    }
}
