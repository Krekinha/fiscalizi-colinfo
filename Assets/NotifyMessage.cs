using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscaliZi.Colinfo.Assets
{
    public class NotifyMessage
    {
        public string Message { get; private set; }
        public string Code { get; private set; }

        public NotifyMessage(string _msg, string _code)
        {
            Message = _msg;
            Code = _code;
        }
    }
}
