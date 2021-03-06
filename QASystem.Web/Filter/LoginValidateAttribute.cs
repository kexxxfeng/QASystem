﻿using QASystem.Web.Helper;
using System.Web.Mvc;

namespace QASystem.Web.Filter
{
    /// <summary>
    /// 管理员 身份验证 过滤器
    /// </summary>
    public class LoginValidateAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        /// <summary>
        /// 验证方法 - 在 ActionExcuting过滤器之前执行
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {

            //检查 被请求的 方法 和 控制器是否有 Skip 标签，如果有，则不验证；如果没有，则验证
            if (!filterContext.ActionDescriptor.IsDefined(typeof(Attributes.LoginSkipAttribute), false) &&
                !filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(Attributes.LoginSkipAttribute), false))
            {
                //1.验证用户是否登陆(Session && Cookie)
                if (!OperateContext.Current.IsLogin())
                {
                    filterContext.Result = new RedirectResult("/Account/Login");
                }
            }
            //base.OnAuthorization(filterContext);
        }
    }
}