using System;

namespace Http.Request.Service.Messages
{
    public abstract class ResponseMessage
    {
        public Guid ResponseCode { get; } = Guid.NewGuid();

        public DateTime ResponseDate { get; } = DateTime.Now;
    }
}
