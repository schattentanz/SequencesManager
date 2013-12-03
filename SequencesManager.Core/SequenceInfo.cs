using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SequencesManager.Core
{
    public class SequenceInfo
    {
        public int RunNumber { get; set; }
        public SequenceType SequenceType { get; set; }
        public int SequenceLength { get; set; }
        public long MaxElement { get; set; }
        public double Average { get; set; }
    }

    public enum SequenceType : byte
    { 
        Fibonacci = 0,
        Catalan = 1,
        Bell = 2
    }
}
