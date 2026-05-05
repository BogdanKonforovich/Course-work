using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_2
{
    internal class DanzigMethod : IShortestPathAlgorithm
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
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < m; j++)
                    {

                        operations++;
                        if (dist[i, j] != Const.INF && dist[j, m] != Const.INF)
                        {
                            if (dist[i, j] + dist[j, m] < dist[i, m])
                            {
                                dist[i, m] = dist[i, j] + dist[j, m];
                                next[i, m] = next[i, j];
                            }
                        }

                        operations++;
                        if (dist[m, j] != Const.INF && dist[j, i] != Const.INF)
                        {
                            if (dist[m, j] + dist[j, i] < dist[m, i])
                            {
                                dist[m, i] = dist[m, j] + dist[j, i];
                                next[m, i] = next[m, j];
                            }
                        }
                    }
                }

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < m; j++)
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

                for (int i = 0; i <= m && !stop; i++)
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
