using System;
using System.Numerics;

namespace LAB1_ELENA_V4
{
    abstract class V4Data // Done
    {
        public V4Data(string Info, double Friqency)
        {
            this.Info = Info;
            this.Friqency = Friqency;
        }
        public string Info { set; get; }
        public double Friqency { set; get; }
        public abstract Complex[] NearMax(float eps);
        public abstract string ToLongString();
        public override string ToString()
        {
            return String.Format("\nMain class information: Info = {0}, Friqency = {1}\n", Info, Friqency);
        }
    }
}
