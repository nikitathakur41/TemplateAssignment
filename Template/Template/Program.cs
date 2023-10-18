using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the array:");
            int size = int.Parse(Console.ReadLine());

            dynamic[] array = new dynamic[size];

            Console.WriteLine("Enter the first value:");
            if (GetInput(out array[0]))
            {
                bool validInput = true;

                for (int i = 1; i < size; i++)
                {
                    Console.WriteLine($"Enter value {i + 1}:");
                    while (!GetInput(out array[i]) || array[i].GetType() != array[0].GetType())
                    {
                        Console.WriteLine("Invalid input. Please enter values of the same data type.");
                        Console.WriteLine($"Enter value {i + 1}:");
                    }
                }

                GetOutput(array);
            }     
        }

        static bool GetInput(out dynamic result)
        {
            string inputValue = Console.ReadLine();
            if (int.TryParse(inputValue, out int intValue))
            {
                result = intValue;
                return true;
            }
            else if (double.TryParse(inputValue, out double doubleValue))
            {
                result = doubleValue;
                return true;
            }
            else if (float.TryParse(inputValue, out float floatValue))
            {
                result = floatValue;
                return true;
            }
            else if (!string.IsNullOrEmpty(inputValue))
            {
                result = inputValue;
                return true;
            }

            result = null;
            return false;
        }

        static void GetOutput(dynamic[] array)
        {
            Console.WriteLine("The result is:");
            foreach (var item in array)
            {
                if (item is char[])
                {
                    Console.WriteLine(new string((char[])item));
                }
                else
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}