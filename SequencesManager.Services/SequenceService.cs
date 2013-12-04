using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SequencesManager.Core;
using SequencesManager.DataAccess;

namespace SequencesManager.Services
{
    public class SequenceService
    {
        private readonly ISequenceInfoRepository _sequenceInfoRepository;
        public SequenceService(ISequenceInfoRepository sequenceInfoRepository)
        {
            _sequenceInfoRepository = sequenceInfoRepository;
        }

        public SequenceGeneratingResultInfo AddSequenceInfo(SequenceType sequenceType, int elementsCount)
        {
            try
            {
                ISequence sequence;
                switch (sequenceType)
                {
                    case SequenceType.Fibonacci:
                        sequence = new FibonacciSequence();
                        break;
                    case SequenceType.Catalan:
                        sequence = new CatalanSequence();
                        break;
                    case SequenceType.Bell:
                        sequence = new BellSequence();
                        break;
                    default:
                        sequence = new FibonacciSequence();
                        break;
                }
                var sequenceInfo = new SequenceInfo();
                var cachedSequence = sequence.Sequence.Take(elementsCount).ToList();
                sequenceInfo.SequenceLength = cachedSequence.Count;
                sequenceInfo.MaxElement = cachedSequence.Max();
                sequenceInfo.Average = cachedSequence.Average();
                sequenceInfo.SequenceType = sequenceType;
                _sequenceInfoRepository.AddSequenceInformation(sequenceInfo, cachedSequence);
            }
            catch (OverflowException)
            {
                return new SequenceGeneratingResultInfo { ExceptionInfo = "Unable to compute the requested sequence. Try to set a smaller number of elements.", SequenceGeneratingResult = SequenceGeneratingResult.Overflow };
            }
            catch(Exception ex)
            {
                return new SequenceGeneratingResultInfo{ ExceptionInfo = ex.Message, SequenceGeneratingResult = SequenceGeneratingResult.OtherException };
            }
            return new SequenceGeneratingResultInfo{ SequenceGeneratingResult = SequenceGeneratingResult.Success };
        }

        public IEnumerable<SequenceInfo> GetSequencesInformation()
        {
            return _sequenceInfoRepository.GetSequencesInformation();
        }
        
    }

    public class SequenceGeneratingResultInfo
    {
        public SequenceGeneratingResult SequenceGeneratingResult { get; set; }
        public string ExceptionInfo { get; set; }
    }

    public enum SequenceGeneratingResult
    { 
        Success,
        Overflow,
        OtherException
    }

}
