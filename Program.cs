using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3
{
    class Program
    {
        private static Dictionary<int, List<int>> vertices = new Dictionary<int, List<int>>();
        private static List<int> paths = new List<int>();
        static void Main(string[] args)
        {
            int[,] map = { { 3, 9, 4 }, { 7, 2, 1 }, { 6, 5, 8 } };


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    List<int> postion = new List<int>();
                    if (i - 1 >= 0)
                    {
                        postion.Add(map[i - 1, j]);
                    }
                    if (j - 1 >= 0)
                    {
                        postion.Add(map[i, j - 1]);
                    }

                    if (i + 1 < 3)
                    {
                        postion.Add(map[i + 1, j]);
                    }
                    if (j + 1 < 3)
                    {
                        postion.Add(map[i, j + 1]);
                    }

                    vertices.Add(map[i, j], postion);
                }
            }
            GetSum();
        }


        static void GetSum()
        {
            int maxMoney = 0;
            List<int> nodes = new List<int>();
            foreach (KeyValuePair<int, List<int>> vertice in vertices)
            {                
                int key = vertice.Key;
              
                Tuple<int,List<int>> values = GetMax(vertices[key], key);
             
                if (maxMoney < values.Item1)
                {
                    maxMoney = values.Item1;
                    nodes = values.Item2;
                }
            }

            Console.WriteLine("在这个地图上最多能捡到钱数为{0}", maxMoney);

            Console.WriteLine("行走路径为：");

            for (int i= 0; i<nodes.Count; i++)
            {
                if (i == nodes.Count - 1)
                {
                    Console.Write("{0}", nodes[i]);
                }
                else
                {
                    Console.Write("{0}->", nodes[i]);
                }
                
            }

            Console.ReadKey();

        }

        static Tuple<int,List<int>> GetMax(List<int> neighbors, int key)
        {
            List<int> nodes = new List<int>();
            int sum = 0;

            foreach (int neighbor in neighbors)
            {
                List<int> tempNodes = new List<int>();
               
                int temp = key;
                tempNodes.Add(key);
                if (key < neighbor)
                {
                   List<int> nexts = vertices[neighbor];
                   temp = temp + GetMax(nexts, neighbor).Item1;
                   tempNodes.AddRange(GetMax(nexts, neighbor).Item2);
                }
                if (sum < temp)
                {
                    nodes = tempNodes;
                    sum = temp;
                }
            }

            return new Tuple<int,List<int>>(sum,nodes);

        }

      
     
    }
}
