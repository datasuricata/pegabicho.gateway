namespace pegabicho.api.Filters
{
    //public class APIAuthorize
    //{
    //    public bool AllowAnonymous { get; set; } = false;

    //    public bool CheckAppUser { get; set; } = true;

    //    #region Authorization

    //    protected override bool IsAuthorized(HttpActionContext actionContext)
    //    {
    //        var isAuth = base.IsAuthorized(actionContext);

    //        if (CheckAppUser)
    //        {
    //            var authenticationService = actionContext.Request.GetOwinContext().GetService<UserService>();

    //            bool signedIn = authenticationService.SignIn(actionContext.Request.GetOwinContext().Authentication?.User?.Identity as ClaimsIdentity).Result;

    //            isAuth = isAuth && signedIn;
    //        }

    //        if (AllowAnonymous)
    //        {
    //            isAuth = true;
    //        }

    //        return isAuth;
    //    }

    //    protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
    //    {
    //        base.HandleUnauthorizedRequest(actionContext);

    //        var InfinitusReactor = actionContext.Request.GetOwinContext().GetService<CoreReactor>();

    //        if (InfinitusReactor.DomainManager.DomainNotificationHandler.HasNotifications())
    //        {
    //            var CoreNotificationsExceptions = new DomainNotificationsException("Notifications");
    //            CoreNotificationsExceptions.Notifications = InfinitusReactor.DomainManager.DomainNotificationHandler.Notify().ToList();
    //            var errorResponse = ErrorPresentation.CreateFromException(CoreNotificationsExceptions);
    //            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, errorResponse);
    //        }
    //    }

    //    #endregion Authorization
    //}
}
