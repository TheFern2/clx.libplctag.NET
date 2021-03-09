using System;
using System.Collections.Generic;
using System.Text;

namespace thefern.libplctag.NET
{
    public class Response<T>
    {
        public string TagName { get; }
        public T Value { get; }
        public string[] ArrValue { get; }
        public string Status { get; }

        public Response(string tagName, T value, string status)
        {
            TagName = tagName;
            Value = value;
            Status = status;
        }

        public override string ToString()
        {
            return "Response: " + TagName + " " + Value + " " + Status;
        }
    }
}
