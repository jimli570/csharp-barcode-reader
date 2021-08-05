using System.Collections.Generic;

namespace BarcodeReader.decoder
{
    public interface IDecoder<T>
        where T : class
    {
        List<string> Decode(List<T> data);
    }
}
