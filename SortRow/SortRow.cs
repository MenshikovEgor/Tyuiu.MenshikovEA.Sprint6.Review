using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortRow
{
    public class Class1
    {
        public int[,] Sort(int[,] m, int r)
        {
            for (int i = 0; i < m.GetLength(1); i++)
            {
                for (int j = i + 1; j < m.GetLength(1); j++)
                {
                    if (m[r, i] > m[r, j])
                    {
                        int tmp = m[r, i];
                        m[r, i] = m[r, j];
                        m[r, j] = tmp;
                    }
                }
            }
            return m;

        }
    }
}
