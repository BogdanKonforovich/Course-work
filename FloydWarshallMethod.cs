using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_2
{
    internal class FloydWarshallMethod : IShortestPathAlgorithm
    {
        public ShortestPathResult Calculate(Graph graph)
        {
            int[,] matrix = graph.GetMatrix();
            int n = matrix.GetLength(0);
            long operations = 0;

            int[,] dist = (int[,])matrix.Clone();
            int[,] next = (int[,])dist.Clone();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j && matrix[i, j] != Const.INF)
                        next[i, j] = j;
                    else
                        next[i, j] = -1;
                }
            }

            bool stop = false;

            for (int m = 0; m < n && !stop; m++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        operations++;

                        if (dist[i, m] != Const.INF && dist[m, j] != Const.INF)
                        {
                            if (dist[i, m] + dist[m, j] < dist[i, j])
                            {
                                dist[i, j] = dist[i, m] + dist[m, j];
                                next[i, j] = next[i, m];
                            }
                        }
                    }
                }

                for (int i = 0; i < n && !stop; i++)
                {
                    if (dist[i, i] < 0)
                    {
                        dist = null!;
                        next = null!;
                        stop = true;
                    }
                }
            }

            return new ShortestPathResult(dist, next, stop, operations);
        }
    }
}