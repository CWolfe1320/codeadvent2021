using System;
using System.Collections.Generic;

namespace Dive_
{
    class Program
    {

        static void readInput(string fileLocation, ref List<int> downDist, ref List<int> upDist, ref List<int> forDist)
        {
            string[] lines = System.IO.File.ReadAllLines(@fileLocation);

            for (int i = 0; i < lines.Length; i++)
            {
                string[] tokens = lines[i].Split(' ');

                if(tokens[0] == "forward")
                {
                    forDist.Add(Convert.ToInt32(tokens[1]));
                }
                else if(tokens[0] == "up")
                {
                    upDist.Add(Convert.ToInt32(tokens[1]));
                }
                else if(tokens[0] == "down")
                {
                    downDist.Add(Convert.ToInt32(tokens[1]));
                }
                else
                {
                    Console.WriteLine("Error: Incorrect command.");
                }
            }

        }

        static void distTraveled(ref int horVert, List<int> dist, bool downForward)
        {
            for (int i = 0; i < dist.Count; i++)
            {
                if (downForward)
                {
                    horVert = horVert + dist[i];
                }
                else
                {
                    horVert = horVert - dist[i];
                }
            }
        }

        static void Main(string[] args)
        {
            int horDist = 0;
            int vertDist = 0;
            
            List<int> forDist = new List<int>();
            List<int> upDist = new List<int>();
            List<int> downDist = new List<int>();

            readInput(@"input.txt", ref downDist, ref upDist, ref forDist);

            distTraveled(ref horDist, forDist, true);
            distTraveled(ref vertDist, downDist, true);
            distTraveled(ref vertDist, upDist, false);

            Console.WriteLine(horDist + " * " + vertDist + " = " + horDist * vertDist);


            //Part 2 Refactoring

            int aim = 0;
            int forward = 0;
            int vertical = 0;

            readInput2(@"input.txt", ref vertical, ref forward, ref aim);

            Console.WriteLine(vertical + " * " + forward + " = " + vertical * forward);
        }

        static void readInput2(string fileLocation, ref int vertical, ref int forward, ref int aim)
        {
            string[] lines = System.IO.File.ReadAllLines(@fileLocation);

            for (int i = 0; i < lines.Length; i++)
            {
                string[] tokens = lines[i].Split(' ');

                if (tokens[0] == "forward")
                {
                    forward = forward + Convert.ToInt32(tokens[1]);
                    vertical = vertical + (aim * Convert.ToInt32(tokens[1]));
                }
                else if (tokens[0] == "up")
                {
                    aim = aim - Convert.ToInt32(tokens[1]);
                }
                else if (tokens[0] == "down")
                {
                    aim = aim + Convert.ToInt32(tokens[1]);
                }
                else
                {
                    Console.WriteLine("Error: Incorrect command.");
                }
            }

        }

    }
}
