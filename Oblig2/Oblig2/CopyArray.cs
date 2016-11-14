using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig2
{
    class CopyArray
    {
        public static int[][] CopyArrayLinq(int[][] source)
        {
            return source.Select(s => s.ToArray()).ToArray();
        }

    }
}
