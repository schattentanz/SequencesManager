using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequencesManager.Core
{
    public class CatalanSequence : ISequence
    {
        public IEnumerable<long> Sequence
        {
            get
            {
                int currentNumber = 1;
                long accumulated = 1;
                yield return 1;
                checked
                {
                    while (true)
                    {
                        accumulated = ((2 * (2 * currentNumber - 1)) * accumulated) / (currentNumber + 1);
                        currentNumber++;
                        yield return accumulated;
                    }
                }
            }
        }
    }
}
