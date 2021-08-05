using NUnit.Framework;
using System.Collections.Generic;

namespace BarcodeDecoderTests
{
    [TestFixture]
    class BarodeDecoderTest
    {
        private BarcodeReader.decoder.IDecoder<string> m_barcodeDecoder;

        [SetUp]
        public void Setup()
        {
            m_barcodeDecoder = new BarcodeReader.decoder.BarcodeDecoder();
        }

        [TestCase("▍ ▍   ▍▍ ▍ ▍▍   ▍  ▍▍  ▍   ▍▍ ▍   ▍▍ ▍   ▍▍ ▍ ▍ ▍ ▍▍▍  ▍ ▍▍  ▍▍ ▍▍ ▍▍  ▍  ▍▍▍ ▍▍  ▍▍ ▍   ▍  ▍ ▍", "051000012517")]
        [TestCase("▍ ▍   ▍▍ ▍  ▍▍  ▍  ▍  ▍▍ ▍▍▍▍ ▍ ▍   ▍▍ ▍▍   ▍ ▍ ▍ ▍▍▍  ▍ ▍▍  ▍▍ ▍▍ ▍▍  ▍    ▍ ▍ ▍▍▍  ▍  ▍▍▍ ▍ ▍", "012345012345")]
        [TestCase("▍ ▍ ▍      ▍▍▍ ▍▍ ▍▍ ▍▍▍   ▍ ▍▍   ▍▍ ▍  ▍▍  ▍ ▍ ▍ ▍ ▍▍▍▍▍▍   ▍  ▍  ▍   ▍▍▍ ▍  ▍▍▍  ▍ ▍▍  ▍▍ ▍ ▍", "678901678901")]
        public void DecodeTest(string data, string expected)
        {
            List<string> testData = new List<string> { data };
            List<string> decodedBarcodes = m_barcodeDecoder.Decode(testData);

            Assert.That(decodedBarcodes[0], Is.EqualTo(expected));
        }
    }
}
