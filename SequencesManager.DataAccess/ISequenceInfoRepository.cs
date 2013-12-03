using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SequencesManager.Core;

namespace SequencesManager.DataAccess
{
    public interface ISequenceInfoRepository
    {
        IEnumerable<SequenceInfo> GetSequencesInformation();
        void AddSequenceInformation(SequenceInfo sequenceInformation);
    }
}
