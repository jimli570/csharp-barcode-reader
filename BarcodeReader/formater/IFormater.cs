using System.Collections.Generic;

namespace BarcodeReader.formater
{
    public interface IFormater<T>
        where T : class
    {
        List<string> Format(List<T> decodedBarcodes);
    }
}
