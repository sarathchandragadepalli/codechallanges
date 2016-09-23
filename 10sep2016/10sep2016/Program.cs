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
            Queue<Point> visitedQueue = new Queue<Point>();
            Queue<Point> yettoVisitQueue = new Queue<Point>();
            Dictionary<Point, int> shDictionary = new Dictionary<Point, int>();
            var noofRows = pointsarray.GetLength(0);
            var noofcolumns = pointsarray.GetLength(1);
            try
            {
                if (pointsarray[p.X, p.Y] != 0 || pointsarray[q.X, q.Y] != 0)
                {
                    yettoVisitQueue.Enqueue(p);
                    visitedQueue.Enqueue(p);
                    shDictionary.Add(p, 0);
                    while (yettoVisitQueue.Count > 0)
                    {
                        p = yettoVisitQueue.Dequeue();

                        if (p.X == q.X && p.Y == q.Y)
                        {
                            Console.WriteLine(" Yes Path exists");
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

                Console.WriteLine("No : No path exists between the points");
                return "No";
            }

            catch (Exception ex)
            { 
                return ex.InnerException.ToString();
            }

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

                Console.WriteLine("please enter the elements format{xyz....}");
                string inputstring = Console.ReadLine();
                int countvar = 0, i;
                int[,] pointsarray = new int[noofRows, noofColumns];

                if (inputstring != null && inputstring.Length != noofRows * noofColumns)
                {
                    Console.WriteLine("number of inputs must be equal to rows * columns");
                    return;
                }

                for (i = 0; i < noofRows; i++)
                {
                    int j;
                    for (j = 0; j < noofColumns; j++)
                    {
                        if (inputstring != null)
                            pointsarray[i, j] = Convert.ToInt32(Convert.ToString(inputstring[countvar]));
                        if (pointsarray[i, j] != 0 && pointsarray[i, j] != 1)
                        {
                            Console.WriteLine("please enter only 0's and 1's");
                            return;
                        }
                        countvar++;
                    }
                }

                
                Point p = new Point();
                Point q = new Point();

                Console.WriteLine("please enter  two input points in array {fomat: p1q1 next line p2q2} ");
                var point1 = Console.ReadLine();
                var point2 = Console.ReadLine();
                if(point2 != null && (point1 != null && (point1.Length !=2 || point2.Length != 2)))
                {
                    Console.WriteLine("please enter points in the given format p1q1 nxtline p2q2 ");
                    
                }
                if (point1 != null)
                {
                    p.X = Convert.ToInt32(Convert.ToString(point1[0]));
                    p.Y = Convert.ToInt32(Convert.ToString(point1[1]));
                }
                if (point2 != null)
                {
                    q.X = Convert.ToInt32(Convert.ToString(point2[0]));
                    q.Y = Convert.ToInt32(Convert.ToString(point2[1]));
                }
                CalculateDisplcaement displacement = new CalculateDisplcaement();
                displacement.CalculateLogic(pointsarray, p, q);
            }
            catch (FormatException)
            {
                Console.WriteLine("please enter the proper format");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("please enter input with in the range");
            }
        }
    }
}
