namespace FiscaliZi.MDFast.Model
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
