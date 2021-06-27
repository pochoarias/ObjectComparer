using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    interface IObjectComparer
    {
        string Differences { get; set; }
        bool DeepCompare { get; set; }
        bool CompareElements<T>(T input1, T input2) where T : class;
    }
}
