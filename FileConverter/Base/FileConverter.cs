using System;
using System.Collections.Generic;
using System.Text;

namespace Base
{
    public abstract class FileConverter<TFrom, TTo>
    {
        public abstract TTo ConvertFile(TFrom from);
    }
}
