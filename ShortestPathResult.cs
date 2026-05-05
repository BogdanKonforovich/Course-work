using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_2
{
    internal class ShortestPathResult
    {
        public int[,] Dist { get; }
        public int[,] Next { get; }

        public bool HasNegativeCycle { get; }

        public long Operations { get; }

        public  ShortestPathResult(int[,] distances, int[,] next, bool hasNegativeCycle, long operations)
        {
            Dist = distances;
            Next = next;
            HasNegativeCycle = hasNegativeCycle;
            Operations = operations;
        }
    }
}
