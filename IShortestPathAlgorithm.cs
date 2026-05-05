using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_2
{
    internal interface IShortestPathAlgorithm
    {
       ShortestPathResult Calculate(Graph graph);
    }
}
