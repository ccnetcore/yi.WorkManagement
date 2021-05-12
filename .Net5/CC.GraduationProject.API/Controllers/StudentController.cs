using CC.GraduationProject.Common;
using CC.GraduationProject.IBLL;
using CC.GraduationProject.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.GraduationProject.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StudentController :BaseController
    {
        private IstudentBll _studentBll;
        public StudentController( IstudentBll studentBll)
        {
            _studentBll = studentBll;
        }
        [HttpGet]
        public async Task< IActionResult> GetStudent()
        {
            var data = await _studentBll.GetEntities(n => n.id == studentId).FirstOrDefaultAsync();
            return Content(JsonFactory.Json(data));
        }
        [HttpPost]
        public IActionResult updateStudent(student studentData)
        {
            var data = _studentBll.GetEntities(u => u.id == studentData.id).FirstOrDefault();
            data.student_age = studentData.student_age;
            data.student_class = studentData.student_class;
            data.student_password = studentData.student_password;
            data.student_phone = studentData.student_phone;
            data.student_username = studentData.student_username;

            if (_studentBll.Update(data))
            {
                return Content(JsonFactory.Json(message:"更新成功"));
            }
            return Content(JsonFactory.Json(flag:false, message: "更新失败"));
        }
    }
}
