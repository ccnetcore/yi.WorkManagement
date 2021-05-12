using CC.GraduationProject.Common;
using CC.GraduationProject.IBLL;
using CC.GraduationProject.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace CC.GraduationProject.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private IstudentBll _studentBll;
        private IteacherBll _teacherBll;
        private VerificationCodeAESHelp _verificationCodeAESHelp;

        public AccountController(IstudentBll studentBll, IteacherBll teacherBll, VerificationCodeAESHelp verificationCodeAESHelp)
        {
            IsCheck = 0;
            _studentBll = studentBll;
            _teacherBll = teacherBll;
            _verificationCodeAESHelp = verificationCodeAESHelp;
        }


        [HttpPost]
        public async Task<IActionResult> Login([FromForm] string username, [FromForm] string pwd,[FromForm] string token)//处理登录模块
        {
            if (token == null)
            {
                return Content(JsonFactory.Json(message: "请输入验证码", flag: false));
            }
            else
            {


                if (HttpContext.Session.GetString("token") == token)
                {
                    var studentData = await _studentBll.GetEntities(u => u.student_username == username).FirstOrDefaultAsync();
                    if (studentData != null)
                    {
                        if (studentData.student_password == pwd)
                        {
                            HttpContext.Session.SetString("studentId", studentData.id.ToString());
                            return Content(JsonFactory.Json(message2: studentData.student_username, message: "欢迎同学！" + studentData.student_name, data: 0));//学生登入成功
                        }
                    }
                    else
                    {
                        var teacherData = await _teacherBll.GetEntities(u => u.teacher_username == username).FirstOrDefaultAsync();
                        if (teacherData != null)
                        {
                            if (teacherData.teacher_password == pwd)
                            {
                                HttpContext.Session.SetString("teacherId", teacherData.id.ToString());
                                return Content(JsonFactory.Json(message2: teacherData.teacher_username, message: "欢迎教师！" + teacherData.teacher_name, data: 1));//教师登入成功
                            }
                        }
                    }
                }
                else
                {
                    return Content(JsonFactory.Json(message: "验证码有误，请重新输入", flag: false));
                }

            }
           
            return Content(JsonFactory.Json(message: "用户名或者密码错误", flag: false));
        }

        [HttpPost]
        public IActionResult Register([FromForm] string mail, [FromForm] string username, [FromForm] string pwd, [FromForm] string code)
        {
            string codeData = "abcd".ToUpper();
            if (code.ToUpper() == codeData)
            {
                student studentData = new student();
                studentData.student_username = username;
                studentData.student_mailbox = mail;
                studentData.student_password = pwd;
                _studentBll.Add(studentData);
                return Content(JsonFactory.Json(message: "用户注册成功！"));
            }

            return Content(JsonFactory.Json(flag:false ,message: "验证码错误，请及时修正"));

        }


        [HttpPost]
        public IActionResult ResetPwd([FromForm] string mail, [FromForm] string pwd, [FromForm] string code)
        {
            string codeData = "abcd".ToUpper();
            if (code.ToUpper() == codeData)
            {
               var studentData= _studentBll.GetEntities(u => u.student_mailbox == mail).FirstOrDefault();
                if (studentData == null)
                {
                    return Content(JsonFactory.Json(flag: false, message: "用户不存在"));
                }
                studentData.student_password = pwd;
                if (_studentBll.Update(studentData))
                {
                    return Content(JsonFactory.Json(message: "密码重置成功！"));
                }
                else
                {
                    return Content(JsonFactory.Json(flag: false, message: "密码重置失败！"));
                }
            }

            return Content(JsonFactory.Json(flag: false, message: "验证码错误，请及时修正"));

        }


        [HttpPost]
        public ActionResult LogOff()
        {
            HttpContext.Session.Clear();
            return Content(JsonFactory.Json(message: "安全退出成功！"));
        }
        [HttpPost]
        public ActionResult Logged()//判断session是否过期
        {
            var data1 = HttpContext.Session.GetString("studentId");
            var data2 = HttpContext.Session.GetString("teacherId");
            if (data1 == null && data2 == null)//表示登入已经过期
            {
                return Content(JsonFactory.Json(message: "登入已过期！请重新登入！", flag: false));
            }
            else
            {
                return Content(JsonFactory.Json( flag: true));//session没有过期
            }

        }

        [HttpGet]
        [Route("/VerificationCodeImage")]
        public async Task<IActionResult> GetVerificationCodeImage()
        {
            var model = await VerificationCodeImage.CreateHanZi();
            var json_Model = Newtonsoft.Json.JsonConvert.SerializeObject(model.point_X_Y);
            string pointBase64str = this._verificationCodeAESHelp.AES_Encrypt_Return_Base64String(json_Model);
            this._verificationCodeAESHelp.SetCookie(VerificationCodeAESHelp._YZM, pointBase64str, 5);
            string msg = "请根据顺序点击【" + string.Join("", model.point_X_Y.Select(x => x.Word).ToList()) + "】";
            return Json(new { result = model.ImageBase64Str, msg = msg, code = 200 });
        }



        [Route("/verification/check")]
        [HttpPost]
        public IActionResult CheckCode([FromForm]string code)
        {
            try
            {
                var pointList = new List<Point_X_Y>();
                try
                {
                    pointList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Point_X_Y>>(code);
                }
                catch (Exception)
                {
                    return Json(new { msg = "验证失败!", status = "error", code = 200 });
                }

                if (pointList.Count != 2)
                    return Json(new { msg = "验证失败!", status = "error", code = 200 });

                var _cookie = this._verificationCodeAESHelp.GetCookie(VerificationCodeAESHelp._YZM);

                if (string.IsNullOrEmpty(_cookie))
                    return Json(new { msg = "验证失败!", status = "error", code = 200 });

                string _str = this._verificationCodeAESHelp.AES_Decrypt_Return_String(_cookie);

                var _cookiesPointList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Point_X_Y>>(_str);
                _cookiesPointList = _cookiesPointList.OrderBy(x => x.Sort).ToList();
                int i = 0;
                foreach (var item in pointList.AsParallel())
                {
                    int _x = _cookiesPointList[i]._X - item._X;
                    int _y = _cookiesPointList[i]._Y - item._Y;
                    _x = Math.Abs(_x);
                    _y = Math.Abs(_y);
                    if (_x > 25 || _y > 25)
                    {
                        return Json(new { msg = "验证失败!", status = "error", code = 200 });
                    }
                    i++;
                }

                SlideVerifyCode(true);
            }
            catch (Exception)
            {
            }
            string token = Guid.NewGuid().ToString();
            HttpContext.Session.SetString("token", token);
            return Json(new { msg = "验证通过!", status = "ok",code=200,token= token });
        }



        private (bool, string) VerifyValiate()
        {
            try
            {
                var _cookie = this._verificationCodeAESHelp.GetCookie(VerificationCodeAESHelp._SlideCode);
                if (string.IsNullOrEmpty(_cookie))
                {
                    SlideVerifyCode();
                    return (false, "请拖动滑块!");
                }

                string _str = this._verificationCodeAESHelp.AES_Decrypt_Return_String(_cookie);
                var sildeCodeModel = Newtonsoft.Json.JsonConvert.DeserializeObject<SlideVerifyCodeModel>(_str);
                if (!sildeCodeModel.SlideCode)
                    return (false, "请拖动滑块后点击汉字!");

                var _NowTime = DateTime.Now;
                var _time = sildeCodeModel.timestamp;
                var number = (_NowTime - _time).Minutes;
                if (number > 5)
                {
                    SlideVerifyCode();
                    return (false, "滑块验证码过期!");
                }
            }
            catch (Exception)
            {
                return (false, "滑动验证码失败!");
            }
            return (true, "");
        }


        private void SlideVerifyCode(bool _bool = false)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(new SlideVerifyCodeModel() { SlideCode = _bool });
            string base64Str = this._verificationCodeAESHelp.AES_Encrypt_Return_Base64String(json);
            this._verificationCodeAESHelp.SetCookie(VerificationCodeAESHelp._SlideCode, base64Str, 10);

        }
    }
}
