using System;
using System.Collections.Generic;
using System.Net;

namespace Schedulerry.Common.Errors.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(Dictionary<string, List<string>> errors)
        {
            Errors = errors;
        }

        public static HttpStatusCode ErrorCode = HttpStatusCode.BadRequest;

        public Dictionary<string, List<string>> Errors { get; }
    }
}
