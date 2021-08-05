# Barcode Reader

This application reads UPC (Universal Product Code) barcodes from textfiles, each line containing one barcode, and outputs them in decimal-numbers in the console. One filepath can be provided as input to application, otherwise 'testdata1.txt' will be used as default.

Note: The application is also magical, and always recieves the correct input.

## Requirements

- .NET core 2.1

## Running the application

Easiets way to run the application is by executing 'RunApplication.bat' which runs 'dotnet BarcodeReader.dll' for you.

## Solution Structure

- 'BarcodeReader/' contains the Application
- 'Test/' contains the unittests written using NUnit3.

## References

<https://en.wikipedia.org/wiki/Universal_Product_Code>
