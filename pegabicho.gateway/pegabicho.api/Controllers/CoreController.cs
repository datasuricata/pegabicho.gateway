using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using pegabicho.domain.Arguments.Base;
using pegabicho.domain.Entities.Core.Users;
using pegabicho.domain.Interfaces.Services.Base;
using pegabicho.domain.Interfaces.Services.Core;
using pegabicho.domain.Security;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

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
        protected IServiceBase ServiceBase => (IServiceBase)HttpContext.RequestServices.GetService(typeof(IServiceBase));
        protected IServiceUser ServiceUser => (IServiceUser)HttpContext.RequestServices.GetService(typeof(IServiceUser));

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

        /// <summary>
        /// inject reference account
        /// </summary>
        /// <param name="obj"></param>
        protected T InjectAccount<T>(T obj)
        {
            DataSecurity.InjectAccount(obj, Logged);
            return obj;
        }

        /// <summary>
        /// return user info from current context
        /// </summary>
        /// <returns></returns>
        protected User Logged
        {
            get
            {
                return ServiceUser?.GetMe(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
            }
        }

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

        #region [ action result ]

        /// <summary>
        /// return new ObjectResponse or message notification
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected IActionResult Result(object result = null)
        {
            try
            {
                if (ServiceBase.HasNotification())
                    return BadRequest(ServiceBase.GetNotifications());

                if (result == null)
                    return new ObjectResult(new ResponseBase());

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

        #endregion

        #region [ async action result ] 

        // # todo async result response for generic request

        //protected async Task<IActionResult> ResultAsync(object result = null)
        //{
        //    try
        //    {
        //        if (ServiceBase.HasNotification())
        //            return BadRequest(ServiceBase.GetNotifications());

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