using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace web_api
{
    public class LowLevelPlayerResult : ObjectResult
    {
        public LowLevelPlayerResult() : base(null)
        { }

        public LowLevelPlayerResult(object value) : base(value) 
        { }

        public override Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;
            response.StatusCode = StatusCode ?? 400;
            return Task.CompletedTask;
        }
    }
}
