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
    public class CommentController : BaseController
    {

        private IcommentBll _commentBll;
        private IteacherBll _teacherBll;
        private IstudentBll _studentBll;
        public CommentController(IcommentBll commentBll,IteacherBll teacherBll,IstudentBll studentBll)
        {
            _commentBll = commentBll;
            _teacherBll = teacherBll;
            _studentBll = studentBll;

        }
        [HttpGet]
        public async Task<IActionResult> GetCommentListByDiscussId(int discussId)
        {
            var commentData = await _commentBll.GetEntities(u => u.discuss_id == discussId).ToListAsync();
            return Content(JsonFactory.Json(commentData));
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(comment commentData)
        {
            string nameData = "";
            //获取教师名称
            if (studentId != 0)
            {
                var studentData = await _studentBll.GetEntities(u => u.id == studentId).FirstOrDefaultAsync();
                nameData = studentData.student_name;
            }
            else if (teacherId != 0)
            {
                var teacherData = await _teacherBll.GetEntities(u => u.id == teacherId).FirstOrDefaultAsync();
                nameData = teacherData.teacher_name;
            }
           
            commentData.comment_author =nameData;
            commentData.comment_createdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _commentBll.Add(commentData);
            return Content(JsonFactory.Json(message: "评论成功"));
        }

    }
}
