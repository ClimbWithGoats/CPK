namespace CPK
{
    public class InputMessage
    {
        public string? Date { get; set; }
        public int? ResultCode { get; set; }
        public string? Message { get; set; }
        public string? InnerMessage { get; set; }
        public string? ResultJson { get; set; }
        public string? Methods { get; set; }
        public Guid? Guid { get; set; }

        public static Task<InputMessage> BadGuid(string guid, string Message)
        {
            return Task.FromResult(new InputMessage()
            {
                Date = DateTime.Now.ToString("s"),
                Message = Message,
                Methods = nameof(BadGuid)
            });
        }

        public static Task<InputMessage> ResultOk(string message, string v)
        {
            return Task.FromResult(
             new InputMessage()
             {
                 Date = DateTime.Now.ToString("s"),
                 Message = message,
                 Methods = nameof(ResultOk)
             });
        }
    }
}
