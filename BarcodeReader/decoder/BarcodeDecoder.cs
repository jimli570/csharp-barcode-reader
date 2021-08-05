using System;
using System.Collections.Generic;

namespace BarcodeReader.decoder
{
    /* Decodes barcodes to decmial values
     * For more information: https://en.wikipedia.org/wiki/Universal_Product_Code
     */
    public class BarcodeDecoder : IDecoder<string>
    {
        private readonly static Dictionary<string, int> LEFT_ENC_DICT = new Dictionary<string, int> {
            { "0001101", 0 }, { "0011001", 1 }, { "0010011", 2 },
            { "0111101", 3 }, { "0100011", 4 }, { "0110001", 5 },
            { "0100000", 6 }, { "0111011", 7 }, { "0110111", 8 }, { "0001011", 9} };

        // Values are complements to values in 'LEFT_GUARD_DICT'
        private readonly static Dictionary<string, int> RIGHT_ENC_DICT = new Dictionary<string, int> {
            { "1110010", 0 }, { "1100110", 1 }, { "1101100", 2 },
            { "1000010", 3 }, { "1011100", 4 }, { "1001110", 5 },
            { "1011111", 6 }, { "1000100", 7 }, { "1001000", 8 }, { "1110100", 9} };

        public List<string> Decode(List<string> data)
        {
            List<string> binary = new List<string>();
            List<string> decimalNums = new List<string>();

            // Parse each line of barcode-data & decode to binary-values
            foreach (string line in data) {
                binary.Add( BarcodeToBinary(line) );
            }

            // Parse each line of binary-data & decode to decmail-values
            foreach (string line in binary) {
                decimalNums.Add( BinaryToDecimal(line) );
            }

            return decimalNums;
        }

        /* Replace "▍" with '1' & ' ' with '0' */
        private string BarcodeToBinary(string line)
        {
            return line.Replace("▍", "1").Replace(" ", "0");
        }

        /* Input-format: 'LEFT_GUARD' value, 6 values from 'LEFT_GUARD_DICT', 
         *               'CENTER_GUARD',
         *               6 values from 'LEFT_ENC_DICT', 'RIGHT_GUARD' value
         *               
         *         Note: 
         *              Assumption that the input always is correct &
         *              the lenght is always the same, so we can use precalculated
         *              positions to find the interesting parts.
        */
        private string BinaryToDecimal(string binaryBarcode)
        {
            string optimizedBarCode = RemoveLeftAndRightGuard( binaryBarcode );

            const int guardLen = 42; // 6 * 7 = 42 (length of each, left & right)
            const int centerGuardLen = 5;

            // Remove center-guard & separate into 'left 'and 'right'
            string left = optimizedBarCode.Substring( 0, guardLen );
            string right = optimizedBarCode.Substring( guardLen + centerGuardLen, guardLen );

            // decimal-values using UPC-A Encoding table
            string leftTranslate = DecodeUPCA( left, BarcodeDecoder.LEFT_ENC_DICT );
            string rightTranslate = DecodeUPCA( right, BarcodeDecoder.RIGHT_ENC_DICT );

            string decimalBarcode = leftTranslate + rightTranslate;

            return decimalBarcode;
        }

        private string RemoveLeftAndRightGuard(string binaryBarcode)
        {
            // Remove left & right guard
            const int leftRightLen = 3; // Guard length of both left & right guard
            const int leftRightTotalLen = 2 * leftRightLen;

            return binaryBarcode.Substring( 3, binaryBarcode.Length - leftRightTotalLen ); // Remove 'LEFT_GUARD' & 'RIGHT_GUARD'
        }

        private string DecodeUPCA(string code, Dictionary<string, int> dict)
        {
            /* both left & right has a length of 42
             * each decimal is represented by 7 binary values in the =>
             * 42/7 = 6, this means there is 6 decimal-values to decode
            */
            const int numOfDecimalValues = 6;
            const int decimalValueLen = 7;

            string decimalValues = "";
            string value;

            // Decode each value
            for (int i = 0; i < numOfDecimalValues; i++) {
                value = code.Substring( i * decimalValueLen, decimalValueLen );

                decimalValues += dict[value].ToString();
            }

            return decimalValues;
        }
    }
}
