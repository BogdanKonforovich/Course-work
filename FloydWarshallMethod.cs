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

            // Ініціалізація матриці шляхів
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

            // Класичний потрійний цикл Флойда-Воршелла
            for (int m = 0; m < n && !stop; m++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        // Лічильник стоїть тут. Він спрацює рівно n^3 разів.
                        operations++;

                        // Перевірка на INF потрібна ЛИШЕ для того, щоб при 
                        // додаванні не відбулося переповнення типу (Integer Overflow),
                        // але вона не пропускає сам цикл по j, як у вашій оптимізації.
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

                // Перевірка на від'ємний цикл
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