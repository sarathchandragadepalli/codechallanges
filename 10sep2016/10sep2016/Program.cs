using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace _10sep2016
{
    public class CalculateDisplcaement
    {
        static void Main(string[] args)
        {
            TakeInputandcalculateLogic();
            Console.ReadLine();
            
        }

        public string CalculateLogic(int[,] pointsarray, Point p, Point q)
        {
            bool path = false;
            Queue<Point> visitedQueue = new Queue<Point>();
            Queue<Point> yettoVisitQueue = new Queue<Point>();
            var noofRows = pointsarray.GetLength(0);
            var noofcolumns = pointsarray.GetLength(1);
            int count = 0;
            try
            {
                if (pointsarray[p.X, p.Y] == 0 || pointsarray[q.X, q.Y] == 0)
                {
                    Console.WriteLine("No : No path exists between the points");
                    return "No";
                }
                yettoVisitQueue.Enqueue(p);
                visitedQueue.Enqueue(p);
                Dictionary<Point, int> shDictionary = new Dictionary<Point, int>();
                shDictionary.Add(p, count);
                while (yettoVisitQueue.Count > 0)
                {
                    p = yettoVisitQueue.Dequeue();

                    if (p.X == q.X && p.Y == q.Y)
                    {
                        Console.WriteLine(" Yes Path exists");
                        path = true;
                        Console.WriteLine("shortest distance is:" + shDictionary[p]);
                        return "Yes " + shDictionary[p];
                    }
                    if (p.X - 1 >= 0 && pointsarray[p.X - 1, p.Y] == 1)
                    {
                        Point x = new Point(p.X - 1, p.Y);

                        if (!visitedQueue.Contains(x))
                        {
                            visitedQueue.Enqueue(x);
                            yettoVisitQueue.Enqueue(x);
                            shDictionary.Add(x, shDictionary[p] + 1);
                        }
                    }
                    if (p.X + 1 < noofRows && pointsarray[p.X + 1, p.Y] == 1)
                    {
                        Point x = new Point(p.X + 1, p.Y);

                        if (!visitedQueue.Contains(x))
                        {
                            visitedQueue.Enqueue(x);

                            yettoVisitQueue.Enqueue(x);
                            shDictionary.Add(x, shDictionary[p] + 1);
                        }
                    }
                    if (p.Y + 1 < noofcolumns && pointsarray[p.X, p.Y + 1] == 1)
                    {
                        Point x = new Point(p.X, p.Y + 1);

                        if (!visitedQueue.Contains(x))
                        {
                            visitedQueue.Enqueue(x);
                            yettoVisitQueue.Enqueue(x);
                            shDictionary.Add(x, shDictionary[p] + 1);
                        }
                    }
                    if ((p.Y - 1) >= 0 && pointsarray[p.X, p.Y - 1] == 1)
                    {
                        Point x = new Point(p.X, p.Y - 1);

                        if (!visitedQueue.Contains(x))
                        {
                            visitedQueue.Enqueue(x);
                            yettoVisitQueue.Enqueue(x);
                            shDictionary.Add(x, shDictionary[p] + 1);
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Please enter the input points in between the range");
                return "please try the input within the range";
            }
            if (!path)
                Console.WriteLine("No : No path exists between the points");
            return "No";
        }

        private static void TakeInputandcalculateLogic()
        {
            try
            {
                Console.WriteLine("please enter the number of rows");
                var noofRows = Convert.ToInt32(Console.ReadLine());
                if (noofRows < 0 || noofRows >= 100)
                {
                    Console.WriteLine("no of rows must be greater than 0 and less than 100");
                    noofRows = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("please enter the number of columns");
                var noofColumns = Convert.ToInt32(Console.ReadLine());
                if (noofColumns < 0 || noofColumns >= 100)
                {
                    Console.WriteLine("no of columns must be greater than 0 and less than 100");
                    noofColumns = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("please enter the elements {Format : x1 x2 x3 .... } ");
                int[,] pointsarray = new int[noofRows, noofColumns];
                int i, k = 0;
                /* output each array element's value */
                var inpurArray = Console.ReadLine().Trim();
                string[] inputvalues = inpurArray != null ? inpurArray.Split() : null;
                int[] inputarrayvalues = Array.ConvertAll(inputvalues, int.Parse);
                if (inputarrayvalues.Length != noofRows * noofColumns)
                {
                    Console.WriteLine("number of inputs must be equal to rows * columns");
                    return;
                }
                for (i = 0; i < noofRows; i++)
                {
                    int j;
                    for (j = 0; j < noofColumns; j++)
                    {
                        pointsarray[i, j] = inputarrayvalues[j + k];
                        if (pointsarray[i, j] != 0 && pointsarray[i, j] != 1)
                        {
                            Console.WriteLine("please enter only 0's and 1's as input");
                            return;
                        }
                    }
                    k += j;
                }
                Console.WriteLine("please enter  two input points in array {fomat: p1 q1 next line  p2 q2} ");
                Point p = new Point();
                Point q = new Point();
                var point1 = Console.ReadLine();
                string[] tokens = point1 != null ? point1.Split() : null;
                int[] numbers = Array.ConvertAll(tokens, int.Parse);
                p.X = numbers[0];
                p.Y = numbers[1];
                var point2 = Console.ReadLine();
                string[] tokens2 = point2 != null ? point2.Split() : null;
                int[] numbers2 = Array.ConvertAll(tokens2, int.Parse);
                q.X = numbers2[0];
                q.Y = numbers2[1];
                CalculateDisplcaement displacement = new CalculateDisplcaement();
                displacement.CalculateLogic(pointsarray, p, q);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("please enter the proper format");
            }
        }
    }
}
