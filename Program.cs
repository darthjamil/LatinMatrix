using System;
using System.Collections.Generic;

namespace LatinMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var numTests = int.Parse(Console.ReadLine());

            for (var i = 1; i <= numTests; i++)
            {
                Solve(i);
            }
        }

        private static void Solve(int testNumber)
        {
            var n = int.Parse(Console.ReadLine());
            
            var matrix = ReadMatrix(n);
            OutputAnswers(n, matrix);
        }

        private static int[][] ReadMatrix(int size)
        {
            var matrix = new int[size][];

            for (var i = 0; i < size; i++)
            {
                matrix[i] = BuildRow(size);
            }

            return matrix;
        }

        private static int[] BuildRow(int size)
        {
            var row = new int[size];
            var rowString = Console.ReadLine();
            var cells = rowString.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            for (var j = 0; j < size; j++)
            {
                var cellValue = int.Parse(cells[j]);
                row[j] = cellValue;
            }

            return row;
        }

        private static void OutputAnswers(int testNumber, int[][] matrix)
        {
            var k = GetTrace(matrix);
            var r = GetNumRowsWithRepeatedElements(matrix);
            var c = GetNumColsWithRepeatedElements(matrix);

            Console.WriteLine($"Case #{testNumber}: {k} {r} {c}");
        }

        private static int GetNumRowsWithRepeatedElements(int[][] matrix)
        {
            var numRows = 0;

            for (var i = 0; i < matrix.Length; i++)
            {
                if (HasRepetition(matrix[i]))
                {
                    numRows++;
                }
            }

            return numRows;
        }

        private static int GetNumColsWithRepeatedElements(int[][] matrix)
        {
            var numCols = 0;

            for (var i = 0; i < matrix.Length; i++)
            {
                int[] column = ExtractColumn(matrix, i);

                if (HasRepetition(column))
                {
                    numCols++;
                }
            }

            return numCols;
        }

        private static int[] ExtractColumn(int[][] matrix, int colNum)
        {
            var column = new int[matrix.Length];

            for (var j = 0; j < matrix.Length; j++)
            {
                column[j] = matrix[j][colNum];
            }

            return column;
        }

        private static bool HasRepetition(int[] dimension)
        {
            var elementsBloom = new Dictionary<int, bool>();

            for (var i = 0; i < dimension.Length; i++)
            {
                if (elementsBloom.ContainsKey(dimension[i]))
                {
                    return true;
                }

                elementsBloom[dimension[i]] = true;
            }

            return false;
        }

        private static int GetTrace(int[][] matrix)
        {
            var sum = 0;

            for (var i = 0; i < matrix.Length; i++)
            {
                sum += matrix[i][i];
            }

            return sum;
        }
    }
}
