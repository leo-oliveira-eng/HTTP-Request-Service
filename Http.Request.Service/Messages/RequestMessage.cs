using System;

namespace Http.Request.Service.Messages
{
    public abstract class RequestMessage
    {
        public Guid RequestCode { get; } = Guid.NewGuid();

        public DateTime RequestDate { get; } = DateTime.Now;
    }
}
