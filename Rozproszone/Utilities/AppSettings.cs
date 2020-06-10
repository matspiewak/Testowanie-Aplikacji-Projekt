using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rozproszone.Utilities
{
    public class AppSettings
    {
        public string Secret { get; set; }

        public static implicit operator AppSettings(string v)
        {
            throw new NotImplementedException();
        }
    }
}
