using System;
using System.Collections.Generic;

namespace BarcodeReader.formater
{

    /* Validate the barcodes */
    public class BarcodeFormater : IFormater<string>
    {
        public List<string> Format(List<string> decodedBarcodes)
        {
            List<string> formatedBarcodes = new List<string>();

            // Parse barcode-data & decode to binary-values
            foreach (string line in decodedBarcodes) {
                formatedBarcodes.Add( FormatBarCode(line) );
            }

            return formatedBarcodes;
        }

        string FormatBarCode(string decodedBarcode)
        {
            // Digit system is specified in first position
            string digitSystem = decodedBarcode.Substring( 0, 1 );

            // Modulus is specified in last position
            string modulus = decodedBarcode.Substring( decodedBarcode.Length - 1, 1 );

            // Left & right got a 5 numerical values each, inbetweeen the digitSystem & Modulus-value
            string left = decodedBarcode.Substring( 1, 5 );
            string right = decodedBarcode.Substring( decodedBarcode.Length - 6, 5 );

            string formated = String.Format("{0} {1} {2} {3}", digitSystem, left, right, modulus);


            return formated;
        }
    }
}
