using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SequencesManager.Core.Tests
{
    [TestFixture]
    public class SequencesTests
    {
        [Test]
        public void TestFibonacciSequence()
        {
            var fibonacciSequence = new FibonacciSequence();
            var expectedSequence = new long[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89};

            var actualSequence = fibonacciSequence.Sequence.Take(12);
            
            Assert.IsTrue(expectedSequence.SequenceEqual(actualSequence));
        }

        [Test]
        public void TestCatalanSequence()
        {
            var catalanSequence = new CatalanSequence();
            var expectedSequence = new long[] { 1, 1, 2, 5, 14, 42, 132, 429, 1430, 4862, 16796, 58786 };

            var actualSequence = catalanSequence.Sequence.Take(12);

            Assert.IsTrue(expectedSequence.SequenceEqual(actualSequence));
        }

        [Test]
        public void TestBellSequence()
        {
            var bellSequence = new BellSequence();
            var expectedSequence = new long[] { 1, 1, 2, 5, 15, 52, 203, 877, 4140, 21147, 115975, 678570 };

            var actualSequence = bellSequence.Sequence.Take(12);

            Assert.IsTrue(expectedSequence.SequenceEqual(actualSequence));
        }
    }
}
