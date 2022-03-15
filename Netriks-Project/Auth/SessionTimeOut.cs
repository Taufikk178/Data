using Netriks_Project.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;
using Netriks_Project.Models;

namespace Netriks_Project.Auth
{
    public class SessionTimeOut: System.Web.Mvc.ActionFilterAttribute
    {
        public override async void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (ctx.Session["CID"] != null)
            {
                //ctx.Session["Token"] = "";

                if (ctx.Session["c_username"].ToString() != "" && ctx.Session["c_password"].ToString() != "")
                {

                    if (ctx.Session["Token"].ToString().Trim() == "")
                    {
                        AccountController Obj = new AccountController();
                        string User = ctx.Session["c_username"].ToString();
                        string Pass = ctx.Session["c_password"].ToString();

                        var obj1 = new Token()
                        {
                            Mobile = User,
                            Password = Pass,
                            grant_type = "password"
                        };

                        string Token = await Obj.Tokens(obj1);
                        ctx.Session["Token"] = Token;

                    }
                }

                
                if (ctx.Session["Token"].ToString().Trim() == "")
                {

                    filterContext.Result = new RedirectResult("~/Account/AdminLogin");
                    return ;
                }
                else
                {
                    ctx.Session["Token"] = ctx.Session["Token"].ToString().Trim();

                    if (ctx.Session["CID"] != null)
                    {
                        ctx.Session["CID"] = ctx.Session["CID"].ToString();
                        ctx.Session["c_username"] = ctx.Session["c_username"].ToString();
                    }
                    else
                    {
                        if (ctx.Session["EmpId"] != null)
                        {
                            ctx.Session["EmpId"] = ctx.Session["EmpId"].ToString();
                            ctx.Session["EmpName"] = ctx.Session["EmpName"].ToString();

                        }
                        else if (ctx.Session["SuperId"] != null)
                        {
                            if (ctx.Session["SuperUser"] != null)
                            {
                                ctx.Session["SuperId"] = ctx.Session["SuperId"].ToString();
                                ctx.Session["SuperUser"] = ctx.Session["SuperUser"].ToString();
                            }
                            else
                            {
                                filterContext.Result = new RedirectResult("~/Account/SuperLogin");
                                return;
                            }
                        }
                        else
                        {
                            filterContext.Result = new RedirectResult("~/Account/AdminLogin");
                            return;
                        }

                    }
                }
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Account/AdminLogin");
                return;
            }
            base.OnActionExecuting(filterContext);
        }

    }
}