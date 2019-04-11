using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using pegabicho.domain.Arguments.Base;
using pegabicho.domain.Interfaces.Services.Base;
using System;

namespace pegabicho.api.Controllers 
{
    //[Authorize]
    //[ApiController]
    public class CoreController : ControllerBase
    {
        #region [ parameters ]

        /// <summary>
        /// User Service {Session Manager}
        /// </summary>
        protected IServiceBase ServiceBase => 
            (IServiceBase)HttpContext.RequestServices.GetService(typeof(IServiceBase));


        /// <summary>
        /// inject reference Id into argument
        /// </summary>
        /// <param name="any class argument"></param>
        /// <param name="logged user"></param>
        //private delegate void UserInjector(object obj, User user);
        //private UserInjector UI = Utils.UserInjector;

        #endregion

        #region [ ctor ]

        /// <summary>
        /// ctor
        /// </summary>
        protected CoreController()
        {

        }

        #endregion

        #region [ methods ]

        ///// <summary>
        ///// inject reference account
        ///// </summary>
        ///// <param name="obj"></param>
        //protected T InjectAccount<T>(T obj)
        //{
        //    UI.Invoke(obj, LoggedUser);
        //    return obj;
        //}

        ///// <summary>
        ///// return user info from current context
        ///// </summary>
        ///// <returns></returns>
        //protected User LoggedUser
        //{
        //    get
        //    {
        //        return Service?.GetMe(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
        //    }
        //}

        ///// <summary>
        ///// return user info from current context whit details
        ///// </summary>
        ///// <returns></returns>
        //protected User LoggedUserDetail
        //{
        //    get
        //    {
        //        return Service?.GetMeDetails(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
        //    }
        //}

        /// <summary>
        /// return server info used for request
        /// </summary>
        /// <returns></returns>
        protected string ServerUri()
        {
            return Request.GetDisplayUrl();
        }

        /// <summary>
        /// return ip from request context
        /// </summary>
        /// <returns></returns>
        protected string RequestIp()
        {
            return HttpContext.Connection.RemoteIpAddress.ToString();
        }

        #endregion

        #region [ controller ]

        /// <summary>
        /// return new ObjectResponse or message notification
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected IActionResult CreateResponse(object result = null)
        {
            try
            {
                if (ServiceBase.HasNotification())
                    return BadRequest(ServiceBase.GetNotifications());

                if (result == null)
                    return new ObjectResult(new ResponseBase(null));

                return new ObjectResult(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //protected async Task<IActionResult> ResultAsync(object result = null)
        //{
        //    try
        //    {
        //        if (ServiceBase.HasNotification())
        //            return BadRequest(ServiceBase.GetNotification());

        //        if (result == null)
        //            return new ObjectResult(new ResponseBase());

        //        return new ObjectResult(result);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return NotFound(ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}

        #endregion
    }
}