using System;
using System.IO;
using Base;

namespace Word.Converters
{
    public class WordToBase64 : FileConverter<Stream, string>
    {
        public override string ConvertFile(Stream from)
        {
            using (var ms = new MemoryStream())
            {
                from.CopyTo(ms);
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }
}
