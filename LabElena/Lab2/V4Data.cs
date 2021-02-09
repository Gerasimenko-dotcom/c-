using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace LAB2_ELENA_V4
{
    public abstract class V4Data : IEnumerable<DataItem>
    {
        public V4Data(string Info, double Friqency)
        {
            this.Info = Info;
            this.Frequency = Friqency;
        }

        public V4Data(StreamReader reader)
        {
            try
            {
                Info = reader.ReadLine();
                try
                {
                    Frequency = double.Parse(reader.ReadLine());
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Строковое представление частоты имеет значение null.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Строкове представление частоты не представляет числовое значение.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Строковое представление частоты представляет число, меньшее MinValue или большее MaxValue");
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

        public string Info { set; get; }
        public double Frequency { set; get; }
        public abstract Complex[] NearMax(float eps);
        public abstract string ToLongString();
        public override string ToString()
        {
            return $"Main class information: Info = {Info}, Friqency = {Frequency}";
        }

        public abstract string ToLongString(string format);
        public abstract IEnumerator<DataItem> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); 
        }
    }
}
