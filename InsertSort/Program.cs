using System;

namespace InsertSort
{
    class Program
    {
        static void Main(string[] args)
        {
            const int Min = 0;
            const int Max = 100;
            var array = new int[10]; 

            var randNum = new Random();
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = randNum.Next(Min, Max);
            }
            Console.WriteLine("Сортировка вставками");
            Console.WriteLine("--------------------");
            Console.Write("Исходный массив: ");   
            foreach (var t in array)
            {
                Console.Write(t + " ");
            }
            for (var i = 1; i < array.Length; i++) 
            {
                var value = array[i];
                var flag = false;
                for (var j = i - 1; j >= 0 && flag != true; ) 
                {
                    if (value < array[j]) 
                    {
                        array[j + 1] = array[j];
                        j--;
                        array[j + 1] = value;
                    }
                    else
                    {
                        flag = true;
                    }
                }
            }
            Console.WriteLine(""); 
            Console.Write("После сортировки: ");   
            foreach (var t in array)
            {
                Console.Write(t + " ");
            }   
        }
    }
}