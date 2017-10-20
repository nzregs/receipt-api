using System;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;

namespace ByteArrayFormatters
{
    public class ByteArrayOutputFormatter : OutputFormatter
    {
        public ByteArrayOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse(ByteArrayFormatters.MediaType));
        }

        protected override bool CanWriteType(Type type)
        {
            return type == typeof(byte[]);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            var array = (byte[])context.Object;
            return context.HttpContext.Response.Body.WriteAsync(array, 0, array.Length);
        }
    }
}