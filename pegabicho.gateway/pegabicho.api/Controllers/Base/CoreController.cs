using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using pegabicho.domain.Arguments.Base;
using pegabicho.domain.Entities.Core.Users;
using pegabicho.domain.Interfaces.Services.Core;
using pegabicho.domain.Interfaces.Services.Events;
using pegabicho.domain.Security;
using System;
using System.Security.Claims;

namespace pegabicho.api.Controllers.Base {

    //[Authorize]
    public class CoreController : ControllerBase {
        #region [ parameters ]

        private IServiceUser serviceUser =>
            (IServiceUser)HttpContext.RequestServices.GetService(typeof(IServiceUser));
        private IEventNotifier notifier =>
            (IEventNotifier)HttpContext.RequestServices.GetService(typeof(IEventNotifier));

        #endregion

        #region [ ctor ]

        /// <summary>
        /// ctor
        /// </summary>
        protected CoreController() {

        }

        #endregion

        #region [ user session ]

        /// <summary>
        /// return user info from current context
        /// </summary>
        /// <returns></returns>
        protected User Logged {
            get {
                return serviceUser?.GetMe(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
            }
        }

        /// <summary>
        /// return user info from current context
        /// </summary>
        /// <returns></returns>
        protected string LoggedLess {
            get {
                return User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
        }

        #endregion

        #region [ methods ]

        /// <summary>
        /// inject reference account
        /// </summary>
        /// <typeparam name="T">Model generic</typeparam>
        /// <param name="obj">Model</param>
        /// <param name="nameOf">Propertie user identifier</param>
        /// <returns>Model with user identifier injected</returns>
        protected T InjectAccount<T>(this T obj, string nameOf) {
            return DataSecurity.InjectAccount(obj, LoggedLess, nameOf);
        }

        /// <summary>
        /// return server info used for request
        /// </summary>
        /// <returns></returns>
        protected string ServerUri() {
            return Request.GetDisplayUrl();
        }

        /// <summary>
        /// return ip from request context
        /// </summary>
        /// <returns></returns>
        protected string RequestIp() {
            return HttpContext.Connection.RemoteIpAddress.ToString();
        }

        #endregion

        #region [ results ]

        /// <summary>
        /// return new ObjectResponse or message notification
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected IActionResult Result(object result = null) {
            try {
                if (notifier.HasAny())
                    return BadRequest(notifier.GetNotifications());

                if (result == null)
                    return new OkObjectResult(new ResponseBase());

                return new OkObjectResult(result);
            } catch (ArgumentException ex) {
                return NotFound(ex);
            } catch (Exception ex) {
                return BadRequest(ex);
            }
        }

        #endregion
    }
}