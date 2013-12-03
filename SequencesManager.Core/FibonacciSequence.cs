using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequencesManager.Core
{
    public class FibonacciSequence : ISequence
    {
        public IEnumerable<long> Sequence
        {
            get 
            {
                long prevNumber = 0;
                long currentNumber = 1;
                yield return 0;
                yield return 1;
                checked
                {
                    while (true)
                    {
                        long accumulated = prevNumber + currentNumber;
                        prevNumber = currentNumber;
                        currentNumber = accumulated;
                        yield return currentNumber;
                    }
                }
            }
        }
    }
}
