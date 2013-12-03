using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequencesManager.Core
{
    public class BellSequence : ISequence
    {
        public IEnumerable<long> Sequence
        {
            get
            {
                yield return 1;
                yield return 1;
                long[] row = new long[1]{ 1 };
                checked
                {
                    while (true)
                    {
                        long[] newRow = new long[row.Length + 1];
                        for (int i = 0; i < row.Length; i++)
                        {
                            if (i == 0)
                                newRow[i] = row[row.Length - 1];
                            newRow[i + 1] = newRow[i] + row[i];
                        }
                        row = newRow;
                        yield return newRow[newRow.Length - 1];
                    }
                }
            }
        }
    }
}
