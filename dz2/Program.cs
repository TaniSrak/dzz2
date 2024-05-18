using System;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace dz2
{
    class Matrix
    {
        private int[,] _matrixData;
        private Random rnd = new Random();

        //public delegate void MatrixAction(ref int value); //передача 


        //private void Generate(ref int value)
        //{
        //    value = rnd.Next(1, 100);
        //}

        //public void PrintMatrix(MatrixAction valueOperation, Action rowAction = null)
        //{
        //    for (int i = 0; i < _matrixData.GetLength(0); i++)
        //    {
        //        for (int J = 0; J < _matrixData.GetLength(1); J++)
        //        {
        //            valueOperation?.Invoke(ref _matrixData[i, J]);
        //        }
        //        rowAction?.Invoke(); //делегат при завершении строки в матрице
        //    }
        //}


        //public Matrix(int x, int y)
        //{
        //    _matrixData = new int[x, y];
        //    PrintMatrix(Generate);
        //}

        //public Matrix(int[,] arr)
        //{
        //    _matrixData = arr;
        //}

        public static double[,] Generate(int rows, int cols, int minValue, int maxValue)
        {
            double[,] matrix = new double[rows, cols];
            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = random.Next(minValue, maxValue + 1);
                }
            }
            return matrix;
        }

        public static void PrintMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task1
            double summ = 0; //сумма всех элементов а и б
            double evenSumm = 0; //сумма четных в а
            double notEvenSumm = 0; //сумма нечетных в б
            double product = 1; //произведение а и б


            //массив а
            double[] A = new double[5];

            Console.WriteLine("Введите 5 чисел для массива A:");
            for (int i = 0; i < A.Length; i++)
            {
                double val = Convert.ToDouble(Console.ReadLine());
                A[i] = val;
                evenSumm += i % 2 == 0 ? val : 0;
                summ += val;
                product *= val;

            }

            Array.ForEach(A, (arg) => Console.Write($"{A} "));


            //массив б
            //Matrix m = new Matrix(3, 4);
            //m.PrintMatrix((Generate));

            double[,] B = new double[3, 4];
            Random random = new Random();

            Console.WriteLine("\n\nМассив B:");
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = random.NextDouble(); // генерим
                    notEvenSumm += j % 2 == 0 ? 0 : B[i, j];
                    summ += B[i, j];
                    product *= B[i, j];
                    Console.Write($"{B[i, j]} ");
                }
                Console.WriteLine();
            }

            double maxCommon = A.Concat(B.Cast<double>()).Max();
            double minCommon = A.Concat(B.Cast<double>()).Min();

            //Task2
            double[,] arr = Matrix.Generate(5, 5, -100, 100);

            Console.WriteLine("\n\nМассив задача 4:");
            Matrix.PrintMatrix(arr);

            double[] shortArr = arr.Cast<double>().ToArray();
            double min = Array.IndexOf(shortArr, shortArr.Min()),
                max = Array.IndexOf(shortArr, shortArr.Max());
            double summMinMax = 0;

            for (int i = 0; i < min; i++)
            {
                if (i == max)
                {
                    break;
                }
                summMinMax += shortArr[i];
            }

            //Task3
            Console.WriteLine("Введите строку для шифрования:");
            string input = Console.ReadLine();
            Console.WriteLine("Введите количество сдвигов:");
            int shift = Convert.ToInt32(Console.ReadLine());
            string input_tmp = "";

            foreach (char el in input)
            {
                input_tmp += Convert.ToChar(Convert.ToInt16(el) + shift);
            }
            input = input_tmp;
            input_tmp = "";
            Console.WriteLine("Зашифрованная строка: " + input);
            foreach (char el in input)
            {
                input_tmp += Convert.ToChar(Convert.ToInt16(el) - shift);
            }
            input = input_tmp;
            Console.WriteLine("Зашифрованная строка: " + input);

            //Task5
            Console.WriteLine("Введите арифметическое выражение (используйте только операции + и -):");
            string input1 = Console.ReadLine();

        }
    }
}
