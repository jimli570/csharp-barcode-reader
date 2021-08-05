using System;
using System.Collections.Generic;

namespace BarcodeReader.reader
{
    public interface IReader<T>
        where T : class
    {
        List<T> Read(string filePath);
    }
}
