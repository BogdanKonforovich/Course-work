using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_2
{
    internal class Graph
    {
        private int[,] matrix;

        public int NumVertices {  get; private set; }

        public Graph (int size)
        {
            NumVertices = size;
            this.matrix = new int[NumVertices, NumVertices];
            InitializeMatrix(matrix, NumVertices);

        }

        private void InitializeMatrix(int[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        matrix[i, j] = 0;
                    }
                    else
                    {
                        matrix[i, j] = Const.INF;
                    }
                }
            }
        }
        private void ValidateVertex(int vertexIndex)
        {
            if (vertexIndex < 0 || vertexIndex >= NumVertices)
            {
                throw new ArgumentOutOfRangeException($"Vertex must be between 1 and {NumVertices}.");
            }
        }

        public void AddEdge(int weight, int start, int end)
        {
            ValidateVertex(start);
            ValidateVertex(end);

            if(start == end)
            {
                throw new InvalidOperationException("The vertices must be different!");
            }

            if (matrix[start, end] != Const.INF)
            {
                throw new InvalidOperationException("Such an edge already exists.");
            }

            if(weight < Const.MIN_WEIGHT ||  weight > Const.MAX_WEIGHT)
            {
                throw new ArgumentOutOfRangeException($"Weight must be between {Const.MIN_WEIGHT} and {Const.MAX_WEIGHT}.");
            }

            matrix[start, end] = weight;
        }

        public void RemoveEdge(int start, int end)
        {
            ValidateVertex(start);
            ValidateVertex(end);

            if (matrix[start, end] == Const.INF)
            {
                throw new InvalidOperationException("Such an edge does not exist.");
            }

            matrix[start, end] = Const.INF;
        }

        public void AddVertex(int ind)
        {
            if (ind < 0 || ind > NumVertices)
            {
                throw new ArgumentOutOfRangeException($"Index must be between 0 and {NumVertices}.");
            }

            if (NumVertices >= Const.MAX_VERTICES)
            {
                throw new InvalidOperationException($"Vertex limit reached ({Const.MAX_VERTICES})");
            }

            NumVertices++;
            int[,] newArray = new int[NumVertices, NumVertices];
            InitializeMatrix(newArray, NumVertices);
            int oldI = 0;
            for (int i = 0; i < newArray.GetLength(0); i++)
            {
                if (i != ind)
                {
                    int oldJ = 0;
                    for (int j = 0; j < newArray.GetLength(1); j++)
                    {
                        if (j != ind)
                        {
                            newArray[i, j] = matrix[oldI, oldJ];
                            oldJ++;
                        }
                    }
                    oldI++;
                }
            }

            matrix = newArray;
        }

        public void RemoveVertex(int ind)
        {

            ValidateVertex(ind);

            if (NumVertices <= Const.MIN_VERTICES)
            {
                throw new InvalidOperationException($"Minimum number of vertices reached ({Const.MIN_VERTICES})");
            }

            NumVertices--;
            int[,] newArray = new int[NumVertices, NumVertices];
            int newI = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i != ind)
                {
                    int newJ = 0;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (j != ind)
                        {
                            newArray[newI, newJ] = matrix[i, j];
                            newJ++;
                        }
                    }
                    newI++;
                }
            }
            matrix = newArray;
        }

        public int[,] GetMatrix()
        {
            return (int[,])matrix.Clone();
        }

        public void FillRandom()
        {
            Random rnd = new Random();
            for (int i = 0; i < NumVertices; i++)
            {
                for (int j = 0; j < NumVertices; j++)
                {
                    if (i != j)
                    {
                        if(rnd.Next(0, 10) < 7)
                        {
                            int weight = rnd.Next(0, Const.MAX_WEIGHT + 1);
                            this.AddEdge(weight, i, j);
                        }
                    }
                }
            }
        }

    }
}
