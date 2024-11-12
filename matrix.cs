using System;
using System.ComponentModel.Design;
namespace _aaa
{
    public class Matrix
    {
        public double[,] matrix1, matrix2, matrix3;



        public Matrix(bool all_three = false, bool print = false)
        {
            if (!all_three)
            {
                matrix1 = new double[2, 2];
                Random rnd = new Random();
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        matrix1[i, j] = rnd.Next(-100, 101);
                    }

                }
                if (print)
                    {
                        for (int i2 = 0; i2 < 2; i2++)
                        {
                            for (int i1 = 0; i1 < 2; i1++)
                            {
                                Console.Write($"{matrix1[i2, i1],10:F3}|");
                            }

                            Console.Write("\n");
                        }
                        Console.Write("\n");
                        return;
                    }
                    return;
                
            }



            //перывй массив
            int n, m;
            Console.WriteLine("введите n и m для массива n*m, затем его элементы");
            n = Convert.ToInt32(Console.ReadLine());
            m = Convert.ToInt32(Console.ReadLine());
            matrix1 = new double[n, m];
            for (int i = 0; i < m; i++)
            {
                for (int i1 = n - 1; i1 >= 0; i1--)
                {
                    matrix1[i1, i] = Convert.ToDouble(Console.ReadLine());
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix1[i, j],12}|");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"\nминимальный повторяющийся элемент - {min_repeat(matrix1)}");

            //второй массив
            Console.WriteLine("введите n для массива n*n");
            n = Convert.ToInt32(Console.ReadLine());
            Random rand = new Random();
            matrix2 = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i > j) matrix2[i, j] = rand.Next(-4500, 45676) / 1000;
                    else matrix2[i, j] = rand.Next(-100000, 100001) / 1000;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix2[i, j],10:F3}|");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"\nминимальный повторяющийся элемент - {min_repeat(matrix2)}");

            //третий массив
            int n1, m1;
            Console.WriteLine("введите n для массива n*n");
            n = Convert.ToInt32(Console.ReadLine());
            matrix3 = new double[n, n];
            int dir = 1;
            int c = 1;
            for (int si = 0; si < n; si++)
            {
                if (dir == 1)
                {
                    n1 = si;
                    m1 = 0;
                    for (int i = 0; i <= si; i++)
                    {
                        matrix3[n1, m1] = c;
                        c++;
                        m1++;
                        n1--;
                    }
                    dir = -1;
                    continue;
                }
                n1 = 0;
                m1 = si;
                for (int i = 0; i <= si; i++)
                {
                    matrix3[n1, m1] = c;
                    c++;
                    m1--;
                    n1++;
                }
                dir = 1;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix3[i, j],7:F0}|");
                }
                Console.WriteLine();
            }


        }

        public double min_repeat(double[,] m)
        {
            double current_min = 9999;
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    if (current_min > m[i, j])
                    {
                        for (int i1 = 0; i1 < m.GetLength(0); i1++)
                        {
                            for (int j1 = 0; j1 < m.GetLength(1); j1++)
                            {
                                if (m[i1, j1] == m[i, j])
                                {
                                    current_min = m[i, j];
                                }
                            }
                        }
                    }
                }
            }
            if (current_min == 9999) Console.WriteLine("пустой массив");
            return current_min;
        }






        public static Matrix operator +(Matrix A, Matrix B)
        {
            int rowsA = A.matrix1.GetLength(0);
            int colsA = A.matrix1.GetLength(1);
            int rowsB = B.matrix1.GetLength(0);
            int colsB = B.matrix1.GetLength(1);

            if (rowsA != rowsB || colsA != colsB)
            {
                throw new ArgumentException("Матрицы должны иметь одинаковые размеры");
            }

            var result = new double[rowsA, colsA];

            for (int i = 0; i < rowsA; i++)
            {
                    for (int k = 0; k < colsA; k++)
                    {
                        result[i, k] = A.matrix1[i, k] + B.matrix1[i, k];
                    }
                }
            Matrix a = new Matrix();
            a.matrix1 = result;
            return a;
            }

        public static Matrix operator -(Matrix A, Matrix B)
        {
            int rowsA = A.matrix1.GetLength(0);
            int colsA = A.matrix1.GetLength(1);
            int rowsB = B.matrix1.GetLength(0);
            int colsB = B.matrix1.GetLength(1);

            if (rowsA != rowsB || colsA != colsB)
            {
                throw new ArgumentException("Матрицы должны иметь одинаковые размеры");
            }

            var result = new double[rowsA, colsA];

            for (int i = 0; i < rowsA; i++)
            {
                for (int k = 0; k < colsA; k++)
                {
                    result[i, k] = A.matrix1[i, k] - B.matrix1[i, k];
                }
            }
            Matrix a = new Matrix();
            a.matrix1 = result;
            return a;
        }

        public static Matrix operator *(double m, Matrix A)
        {
            int rowsA = A.matrix1.GetLength(0);
            int colsA = A.matrix1.GetLength(1);

            var result = new double[rowsA, colsA];

            for (int i = 0; i < rowsA; i++)
            {
                for (int k = 0; k < colsA; k++)
                {
                    result[i, k] = m * A.matrix1[i, k];
                }
            }
            Matrix a = new Matrix();
            a.matrix1 = result;
            return a;
        }

        public Matrix transpose()
        {
            int rowsA = matrix1.GetLength(0);
            int colsA = matrix1.GetLength(1);

            var result = new double[rowsA, colsA];

            for (int i = 0; i < rowsA; i++)
            {
                for (int k = 0; k < colsA; k++)
                {
                    result[i, k] = matrix1[k, i];
                }
            }
            Matrix a = new Matrix();
            a.matrix1 = result;
            return a;
        }

        public override string ToString()
        {
            string a = "";
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    a+=$"{matrix1[i, j],10:F3}|";
                }
                a += "\n";
            }
            return a;
        }

    }


    }


