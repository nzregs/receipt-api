using System;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using System.IO;

namespace ByteArrayFormatters
{
    public class ByteArrayInputFormatter : InputFormatter
    {
        public ByteArrayInputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse(ByteArrayFormatters.MediaType));
        }

        protected override bool CanReadType(Type type)
        {
            return type == typeof(byte[]);
        }

        public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {
            var stream = new MemoryStream();
            context.HttpContext.Request.Body.CopyTo(stream);
            return InputFormatterResult.SuccessAsync(stream.ToArray());
        }
    }
}