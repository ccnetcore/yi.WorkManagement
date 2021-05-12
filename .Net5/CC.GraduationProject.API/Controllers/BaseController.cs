using CC.GraduationProject.Common;
using CC.GraduationProject.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.GraduationProject.API.Controllers
{
    public class BaseController : Controller//使用.netcore管道
    {
        public int IsCheck = 1;//设置是否需要校验用户是否登录属性
        public int studentId = 0;//0代表没有
        public int teacherId = 0;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            switch (IsCheck)
            {
                case 1://表示学生获得教师登入需要检验
                    var data1 = HttpContext.Session.GetString("studentId");
                    var data2 = HttpContext.Session.GetString("teacherId");
                    if (data1 != null || data2 != null)//表示已经登入过
                    {
                        studentId = Convert.ToInt32(data1);
                        teacherId = Convert.ToInt32(data2);
                    }
                    else
                    {
                        filterContext.Result = Content(JsonFactory.Json(message: "登录已过期", flag: false));
                    }
                    break;
                case 0:
                    return;
            }
        }
    }
}
