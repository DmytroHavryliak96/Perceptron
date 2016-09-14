using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Perceptron
    {
        public int[,] x = new int[8, 3]; /*
            /*{ 0, 0, 0 },
            { 0, 0, 1 },
            { 0, 1, 0 },
            { 0, 1, 1 },
            { 1, 0, 0 },
            { 1, 0, 1 },
            { 1, 1, 0 },
            { 1, 1, 1 }
        };*/
        //private bool[,] x1 = new bool[8, 3];
        public double[] weights = new double[3];
        public const double rate = 0.1;
        public const double teta = 0.3;
        public int out1;
        public int[] sigma = new int[8];
        public double a;
        public int true_result;
        public double[]  delta = new double[3];

        public Perceptron()
        {
            for(int i = 0; i<weights.Length; i++) {
                Random rdn = new Random();
                weights[i] = rdn.NextDouble() * (5.0) + 0.0;  
            }
        }

        /*public void proceed()
        {
            for (int i = 0; i < 8; i++)
            { 
                activation(i);
                study(i);
                Output(i);
            }
            Console.WriteLine();
        }*/

        public void check()
        {
            bool finish;
            //title();
            do
            {
                finish = false;
                //proceed();
                for (int i = 0; i < sigma.Length; i++)
                {
                    if (sigma[i] != 0)
                    {
                        finish = true;
                        break;
                    }
                    else continue;
                }
            } while (finish);
        }

        /*public void Output(int j)
        {
            for (int i = 0; i < weights.Length; i++)
            {
                Console.Write(Convert.ToString(weights[i]).PadRight(4));
            }
            Console.Write(Convert.ToString(teta).PadRight(4));

            Console.Write(Convert.ToString(x[j, 0]).PadRight(4));
            Console.Write(Convert.ToString(x[j, 1]).PadRight(4));
            Console.Write(Convert.ToString(x[j, 2]).PadRight(4));

            Console.Write(Convert.ToString(a).PadRight(4) + Convert.ToString(out1).PadRight(4)
                + Convert.ToString(true_result).PadRight(4));

           // Console.Write(Convert.ToString(rate * sigma[j]).PadRight(4));
            /*Console.Write(Convert.ToString(delta2).PadRight(4));
            Console.Write(Convert.ToString(delta3).PadRight(4));*/

            /*for (int i = 0; i < weights.Length; i++)
            {
                Console.Write(Convert.ToString(sigma[j]*weights[i]).PadRight(4));
            }
            Console.Write(Convert.ToString(sigma[j] * teta).PadRight(4));
            Console.Write(Convert.ToString(sigma[j]).PadRight(4));
            Console.WriteLine();*/
            /*for (int i = 0; i < 3; i++)
            {
                Console.Write(Convert.ToString(delta[i]).PadRight(4));
            }

            Console.Write(Convert.ToString(sigma[j]).PadRight(4));
            Console.WriteLine();

        }*/

        /*public void title()
        {
            Console.WriteLine("w1".PadRight(4) + "w2".PadRight(4) + "w3".PadRight(4) +
                "te".PadRight(4) + "x1".PadRight(4) + "x2".PadRight(4) + "x3".PadRight(4) +
                    "a".PadRight(4) + "ou".PadRight(4) + "tr".PadRight(4) + "d1".PadRight(4) +
                        "*d1".PadRight(4) + "*d3".PadRight(4) + "si".PadRight(4));
        }
        */
        public void activation(int i)
        {
            true_result = Convert.ToInt32(!Convert.ToBoolean(x[i, 0]) && (!Convert.ToBoolean(x[i, 1]) || Convert.ToBoolean(x[i, 2])));
            a = x[i, 0] * weights[0] + x[i, 1] * weights[1] + x[i, 2] * weights[2];
            if (a > teta)
            {
                out1 = 1;
            }
            else
            {
                out1 = 0;
            }
            sigma[i] = true_result - out1;
        }

        public void study(int i)
        {
            if (out1 != true_result)
            {

                delta[0] = rate * sigma[i] * x[i, 0];
                delta[1] = rate * sigma[i] * x[i, 1];
                delta[2] = rate * sigma[i] * x[i, 2];

                weights[0] += delta[0];
                weights[1] += delta[1];
                weights[2] += delta[2];
            }

        }
    }
}


