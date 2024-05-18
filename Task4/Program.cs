using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Matrix
    {
        private int[,] _matrixData;
        private Random rnd = new Random();

        public delegate void MatrixAction(ref int value); //передача 


        private void FillRandomValue(ref int value)
        {
            value = rnd.Next(1, 100);
        }

        public void MatrixOperation(MatrixAction valueOperation, Action rowAction = null)
        {
            for(int i = 0; i < _matrixData.GetLength(0); i++)
            {
                for (int J = 0; J < _matrixData.GetLength(1); J++)
                {
                    valueOperation?.Invoke(ref _matrixData[i, J]);
                }
                rowAction?.Invoke(); //делегат при завершении строки в матрице
            }
        }


        public Matrix(int x, int y)
        {
            _matrixData = new int[x, y];
            MatrixOperation(FillRandomValue);
        }

        public Matrix(int[,] arr)
        {
            _matrixData = arr;
        }

        //перегрузка
        public static Matrix operator *(Matrix a, int b)
        {
            for (int i = 0; i < a._matrixData.GetLength(0); i++)
            {
                for (int j = 0; j < a._matrixData.GetLength(1); j++)
                {
                    a._matrixData[i, j] *= b;
                }
            }
            return a;
        }

        //сделано так сложно по всем канонам умножения матриц чисто ради интереса
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a._matrixData.GetLength(1) == b._matrixData.GetLength(0))
            {
                int[,] resultMatrix = new int[a._matrixData.GetLength(0), b._matrixData.GetLength(1)];

                for (int i = 0; i < resultMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < resultMatrix.GetLength(1); j++)
                    {
                        for (int k = 0; k < a._matrixData.GetLength(1); k++)
                        {
                            resultMatrix[i,j] += a._matrixData[i, k] * b._matrixData[k, j];
                        }
                    }
                }
                return new Matrix(resultMatrix);
            }
            return null;
        }

        public static Matrix operator +(Matrix a, Matrix b) 
        { 
            if(a._matrixData.GetLength(0) ==  b._matrixData.GetLength(0) &&
                a._matrixData.GetLength(1) == b._matrixData.GetLength(1))
            {
                for (int i = 0; i < a._matrixData.GetLength(0); i++)
                {
                    for (int j = 0; j < a._matrixData.GetLength(1); j++)
                    {
                        a._matrixData[i, j] += b._matrixData[i, j];
                    }
                }
                return a;
            }
            return null;
        }

       
    }


    internal class Program
    {
        static void DisplayMatrixValue(ref int value)
        {
            Console.Write($"{ value} " );
        }

        static void Main(string[] args)
        {
            //Task4
            Matrix m = new Matrix(5, 5);
            m.MatrixOperation((DisplayMatrixValue), ()=> Console.WriteLine());
            Console.WriteLine();
            m *= 2;
            m.MatrixOperation((DisplayMatrixValue), () => Console.WriteLine());
            Console.WriteLine();

            Matrix a = new Matrix(new int[,] { { 15, 18}, { 27,10} });
            Matrix b = new Matrix(new int[,] { { 2 },{ 13 } });

            Matrix res = a * b;
            if(res != null)
            {
                res.MatrixOperation(DisplayMatrixValue, ()=> Console.WriteLine());
            }
            Console.ReadKey();
        }
    }
}
