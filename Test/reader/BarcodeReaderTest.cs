using NUnit.Framework;
using System.Collections.Generic;

namespace BarcodeReaderTests
{
    [TestFixture]
    class BarcodeReaderTest
    {
        private BarcodeReader.reader.IReader<string> m_barcodeReader;

        [SetUp]
        public void Setup()
        {
            m_barcodeReader = new BarcodeReader.reader.BarcodeReader();
        }

        [TestCase("testdata1.txt", "▍ ▍   ▍▍ ▍ ▍▍   ▍  ▍▍  ▍   ▍▍ ▍   ▍▍ ▍   ▍▍ ▍ ▍ ▍ ▍▍▍  ▍ ▍▍  ▍▍ ▍▍ ▍▍  ▍  ▍▍▍ ▍▍  ▍▍ ▍   ▍  ▍ ▍")]
        public void ReaderTest(string path, string expected)
        {
            List<string> decodedBarcodes = m_barcodeReader.Read( path );

            Assert.That( decodedBarcodes[0], Is.EqualTo(expected) );
        }

        [Test]
        public void ReaderNoneExistingTest()
        {
            Assert.Throws( typeof(System.IO.FileNotFoundException), () => m_barcodeReader.Read("noneExistingFile.txt") );
        }
    }
}
