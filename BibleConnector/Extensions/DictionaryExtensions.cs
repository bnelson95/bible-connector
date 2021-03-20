using System;
using System.Collections.Generic;
using System.Linq;

namespace BibleConnector.Extensions
{
    public static class HttpExtensions
    {
        public static string ToQueryString(this Dictionary<string, string> parameters)
        {
            return string.Join('&', parameters.Select(x => x.Key + "=" + x.Value));
        }
    }
}
