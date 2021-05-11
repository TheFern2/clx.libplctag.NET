using System;
using System.Collections.Generic;
using System.Text;

namespace clx.libplctag.NET
{
    public class Response<T>
    {
        public string TagName { get; set; }
        public T Value { get; set; }
        public string Status { get; set; }

        public Response(string tagName, T value, string status)
        {
            TagName = tagName;
            Value = value;
            Status = status;
        }

        public Response(string tagName, string status)
        {
            TagName = tagName;
            Status = status;
        }

        public Response() { }

        public override string ToString()
        {
            return "Response: " + TagName + " " + Value + " " + Status;
        }
    }
}
