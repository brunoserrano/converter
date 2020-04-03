using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Base;

namespace Word.Converters
{
    public class WordToHtml : FileConverter<Stream, string>
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
