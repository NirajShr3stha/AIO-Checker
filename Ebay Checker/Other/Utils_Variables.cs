using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yoboi_legend
{
    public class Captcha
    {
        public string apiKey { get; set; }
        public string siteKey { get; set; }
        public string siteURL { get; set; }
    }
    public enum Hash
    {
        SHA1,
        SHA256,
        SHA512
    }
}
