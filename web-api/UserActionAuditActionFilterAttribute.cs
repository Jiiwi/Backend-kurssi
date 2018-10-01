using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace web_api
{
    public class UserActionAuditActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.Canceled)
            {
                // An request from ip address {insertIpHere} to delete player ended at 9:30:35 12.10 2018
                IRepository _repository = (IRepository) context.HttpContext.RequestServices.GetService(typeof(IRepository));

                string ip = context.HttpContext.Request.Host.Value;
                DateTime currentTime = DateTime.Now;

                LogEntry entry = new LogEntry();
                entry.CreationTime = currentTime;
                entry.Message = "A request from ip address" + ip + " to delete played ended at " + currentTime.ToString();
                entry.Id = Guid.NewGuid();
                _repository.WriteToLog(entry);
            }

        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // An request from ip address {insertIpHere} to delete player started at 9:30:35 12.10 2018
            IRepository _repository = (IRepository) context.HttpContext.RequestServices.GetService(typeof(IRepository));

            string ip = context.HttpContext.Request.Host.Value;
            DateTime currentTime = DateTime.Now;
            LogEntry entry = new LogEntry();
            entry.CreationTime = currentTime;
            entry.Message = "A request from ip address" + ip + " to delete played started at " + currentTime.ToString();
            entry.Id = Guid.NewGuid();
            _repository.WriteToLog(entry);
        }
    }
}