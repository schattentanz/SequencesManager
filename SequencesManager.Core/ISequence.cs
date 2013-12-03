using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequencesManager.Core
{
    public interface ISequence
    {
        IEnumerable<long> Sequence { get; }
    }
}
