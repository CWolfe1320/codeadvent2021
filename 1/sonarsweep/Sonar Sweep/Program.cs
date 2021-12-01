using System;
using System.Collections.Generic;

namespace Sonar_Sweep
{
    class Program
    {

        static String[] readInput(string fileLocation)
        {
            string[] lines = System.IO.File.ReadAllLines(@fileLocation);

            return lines;
        }

        static int sonarMeasurements(String[] data)
        {
            int answer = 0;
            for(int i = 0; i < data.Length - 1; i++)
            {
                if(Convert.ToInt32(data[i + 1]) - Convert.ToInt32(data[i]) > 0)
                {
                    answer++;
                }
            }
            return answer;
        }

        static int sonarMeasurements(List<int> data)
        {
            int answer = 0;
            for (int i = 0; i < data.Count - 1; i++)
            {
                if (data[i + 1] - data[i] > 0)
                {
                    answer++;
                }
            }
            return answer;
        }

        static List<int> sonarSlidingMeasurements(String[] data)
        {
            List<int> tempArray = new List<int>();

            for(int i = 0; i < data.Length - 2; i++)
            {
                tempArray.Add(Convert.ToInt32(data[i]) + Convert.ToInt32(data[i + 1]) + Convert.ToInt32(data[i + 2]));
            }

            return tempArray;
        }

        static void Main(string[] args)
        {
            int answer1 = sonarMeasurements(readInput(@"input.txt"));

            int answer2 = sonarMeasurements(sonarSlidingMeasurements(readInput(@"input.txt")));

            Console.WriteLine(answer1);
            Console.WriteLine(answer2);
        }
    }
}
