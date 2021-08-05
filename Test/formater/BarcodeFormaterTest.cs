using NUnit.Framework;
using System.Collections.Generic;

namespace BarcodeFormaterTests
{
    [TestFixture]
    class BarcodeFormaterTest
    {
        private BarcodeReader.formater.IFormater<string> m_barcodeFormater;

        [SetUp]
        public void Setup()
        {
            m_barcodeFormater = new BarcodeReader.formater.BarcodeFormater();
        }

        [TestCase("051000012517", "0 51000 01251 7")]
        [TestCase("012345012345", "0 12345 01234 5")]
        [TestCase("678901678901", "6 78901 67890 1")]
        public void FormatTest(string data, string expected)
        {
            List<string> testData = new List<string> { data };
            List<string> decodedBarcodes = m_barcodeFormater.Format( testData );
            
            Assert.That( decodedBarcodes[0], Is.EqualTo(expected) );
        }
    }
}
