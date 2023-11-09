using DFDS.Dto;
using DFDS.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace DFDS.Controllers.Middleware
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if(context.Exception is BadRequestException)
            {
                context.Result = new ObjectResult(Envelope.Error(context.Exception.Message)) { StatusCode = (int)HttpStatusCode.BadRequest };
                return;
            }

            if(context.Exception is NotFoundException)
            {
                context.Result = new ObjectResult(Envelope.Error(context.Exception.Message)) { StatusCode = (int)HttpStatusCode.NotFound };
                return;
            }

            context.Result = new ObjectResult(Envelope.Error("Internal Error")) { StatusCode = (int)HttpStatusCode.InternalServerError};
        }
    }
}
