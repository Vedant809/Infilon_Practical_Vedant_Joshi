using System.Diagnostics;
using System.Threading.Tasks;

namespace Student_Courses.Middleware
{
    public class loggingmiddleware
    {
        private readonly RequestDelegate _request;

        public loggingmiddleware(RequestDelegate request)
        {
            _request = request;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Debug.WriteLine($"{context.Request.Path} {context.Request.Method} {context.Request.Body}");

            await _request(context);


        }
    }
}
