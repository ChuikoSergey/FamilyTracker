using FamilyTracker.Business.Exceptions;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace FamilyTracker.Web.Infrastucture.ExceptionHandler.ExceptionHandlers
{
    public class GlobalExceptionHandler : System.Web.Http.ExceptionHandling.ExceptionHandler
    {

        public override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            var result = default(CustomHandleResult);
            if (context.Exception is ValidationException)
            {
                result = new CustomHandleResult(HttpStatusCode.BadRequest, context);
            }
            //else if (context.Exception is RepositoryException)
            //{
            //    result = new CustomHandleResult(HttpStatusCode.BadRequest, context);
            //}
            //else if (context.Exception is SecurityException)
            //{
            //    result = new CustomHandleResult(HttpStatusCode.Forbidden, context);
            //}
            //else if (context.Exception is ApiValidationException)
            //{
            //    result = new CustomHandleResult(HttpStatusCode.BadRequest, context);
            //}
            //else if (context.Exception is ApiSecurityException)
            //{
            //    result = new CustomHandleResult(HttpStatusCode.Forbidden, context);
            //}
            //else if (context.Exception is ApiAuthorizationException)
            //{
            //    result = new CustomHandleResult(HttpStatusCode.Unauthorized, context);
            //}
            //else if (context.Exception is ApiException)
            //{
            //    result = new CustomHandleResult(HttpStatusCode.InternalServerError, context);
            //}
            //else
            //{
            //    result = new CustomHandleResult(HttpStatusCode.InternalServerError, context);
            //}
            context.Result = result;

            return base.HandleAsync(context, cancellationToken);
        }
    }
}