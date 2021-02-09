using System;
using System.Numerics;

namespace LAB1_ELENA_V4
{
    class Program
    {
        static void Main(string[] args)
        {
            V4DataOnGrid grid_obj = new V4DataOnGrid("1", 70, new Grid2D(0.1f, 10, 0.1f, 10));
            grid_obj.InitRandom(0, 100);
            Console.WriteLine(grid_obj.ToLongString());

            V4DataCollection data_obj = (V4DataCollection)grid_obj;
            Console.WriteLine(data_obj.ToLongString());

            V4MainCollection collection = new V4MainCollection();
            collection.AddDefaults();
            Console.WriteLine(collection.ToString());
            foreach (V4Data item in collection)
            {
                foreach (Complex i in item.NearMax((float)11.8))
                {
                    Console.Write(i);
                }
                Console.WriteLine();
            }
        }
    }
}