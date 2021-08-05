using System;
using System.IO;
using System.Collections.Generic;

namespace BarcodeReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = GetFilePath( args );

            try {
                // Read file
                reader.IReader<string> barcodeReader = new reader.BarcodeReader();
                List<string> barcodes = barcodeReader.Read( filepath );

                // Decode barcodes
                decoder.IDecoder<string> barcodeDecoder = new decoder.BarcodeDecoder();
                List<string> decodedBarcodes = barcodeDecoder.Decode( barcodes );

                // Format decodedBarcodes
                formater.IFormater<string> barcodeFormater = new formater.BarcodeFormater();
                List<string> formatedBarcodes = barcodeFormater.Format( decodedBarcodes );

                // Print the decoded & formated content
                formatedBarcodes.ForEach( Console.WriteLine );

                Console.ReadLine();
            }
            catch (IOException ex) {
                Console.WriteLine(ex.ToString());
            }
            catch (OutOfMemoryException ex) {
                Console.WriteLine(ex.ToString());
            }
            catch (ArgumentOutOfRangeException ex) {
                Console.WriteLine(ex.ToString());
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }

        private static string GetFilePath(string[] args)
        {
            string filepath;

            // We only take one file as input for now
            if (args.Length == 1)  {
                filepath = args[0];
            } else {
                filepath = "testdata1.txt"; // Default filePath, if none provided
            }

            return filepath;
        }
    }
}