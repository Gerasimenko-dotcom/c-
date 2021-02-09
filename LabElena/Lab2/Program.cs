using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LAB2_ELENA_V4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string format = "f2";
                V4DataOnGrid data = new V4DataOnGrid("./data.txt");
                data.InitRandom(0,100);
                Console.WriteLine(data.ToLongString(format));

                V4MainCollection mainCollection = new V4MainCollection();
                mainCollection.AddDefaults();

                Console.WriteLine("mainCollection");
                Console.WriteLine(mainCollection.ToLongString(format));

                Console.WriteLine($"mainCollection.Avg = {mainCollection.Avg.ToString(format)}");

                Console.WriteLine("mainCollection.NearZero(5.0f)");
                IEnumerable<DataItem> items = mainCollection.NearZero(5.0f);
                foreach (DataItem item in items)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("mainCollection.OnlyOne");
                IEnumerable<Vector2> vectors = mainCollection.OnlyOne;
                foreach (Vector2 vector in vectors)
                {
                    Console.WriteLine(vector);
                }
                Console.WriteLine("Press Enter to Exit...");
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press Enter to Exit...");
                Console.ReadLine();
            }
        }
    }
}
