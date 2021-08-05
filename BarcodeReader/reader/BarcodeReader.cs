using System;
using System.Collections.Generic;
using System.Text;

namespace BarcodeReader.reader
{
    /* Reads textfiles, where each line corresponds to one barcode */
    public class BarcodeReader : IReader<string>
    {
        private readonly static Encoding encoding = Encoding.UTF8;

        public List<string> Read(string filePath)
        {
            System.IO.StreamReader fileReader = new System.IO.StreamReader( filePath, encoding );
            List<string> barcodes = ReadLines( fileReader );

            return barcodes;
        }

        private List<string> ReadLines(System.IO.StreamReader fileReader)
        {
            List<string> barcodes = new List<string>();

            string line;
            while ( (line = fileReader.ReadLine()) != null )
            {
                barcodes.Add(line);
            }

            return barcodes;
        }
    }
}
