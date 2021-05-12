using CC.GraduationProject.Common;
using CC.GraduationProject.IBLL;
using CC.GraduationProject.Model;
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
    public class DiscussController : BaseController
    {
        private IdiscussBll _discussBll;
        private IteacherBll _teacherBll;
        public DiscussController(IdiscussBll discussBll, IteacherBll teacherBll)
        {
            _discussBll = discussBll;
            _teacherBll = teacherBll;
        }
        [HttpGet]
        public async Task<IActionResult> GetDiscussListByCurriculumId(int curriculumId)
        {
            var discusses = await _discussBll.GetEntities(n => n.curriculum_id == curriculumId).ToListAsync();
            return Content(JsonFactory.Json(data: discusses));
        }
        [HttpPost]
        public async Task<IActionResult> AddDiscuss(discuss discussData)
        {
            //获取教师名称
            var teacherData = await _teacherBll.GetEntities(u => u.id == teacherId).FirstOrDefaultAsync();
            discussData.discuss_createdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            discussData.discuss_author = teacherData.teacher_name;
            _discussBll.Add(discussData);
            return Content(JsonFactory.Json(message: "添加成功"));
        }
        [HttpGet]
        public async Task<IActionResult> GetDiscussById(int id)
        {
            var discussData = await _discussBll.GetEntities(u => u.id == id).FirstOrDefaultAsync();
            return Content(JsonFactory.Json(discussData));
        }
    }
}
