using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyReg.Common.Extensions
{
    public static class PrimitiveTypeExtensions
    {
        public static bool HasValue(this string text)
        {
            if (string.IsNullOrEmpty(text) && string.IsNullOrWhiteSpace(text))
                return false;
            return true;
        }

    }
}
