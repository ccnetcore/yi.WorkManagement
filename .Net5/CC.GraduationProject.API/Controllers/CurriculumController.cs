using CC.GraduationProject.IBLL;
using CC.GraduationProject.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using CC.GraduationProject.Common;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace CC.GraduationProject.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CurriculumController : BaseController
    {
        private Istudent__curriculumBll _student__CurriculumBll;
        private IcurriculumBll _curriculumBll;
        public CurriculumController(Istudent__curriculumBll student__CurriculumBll,IcurriculumBll curriculumBll)
        {
            _student__CurriculumBll = student__CurriculumBll;
            _curriculumBll = curriculumBll;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentCurriculumList()//通过登入的学生id得到他的课表
        {
           var  CurriculumsID= await _student__CurriculumBll.GetEntities(n=> n.student_id==studentId&&n.is_result==1).ToListAsync();
            List<curriculum> curriculums = new List<curriculum>();
            foreach (var k in CurriculumsID)
            {
             var curriculum= await  _curriculumBll.GetEntities(n => n.id == k.curriculum_id).FirstOrDefaultAsync();
                curriculums.Add(curriculum);
            }
            return Content(JsonFactory.Json(curriculums));
        }

        [HttpGet]
        public async Task<IActionResult> GetCurriculumList() //获取所有课程，包括选择和未选择的
        {
            List<curriculum> curriculums = new List<curriculum>();
            curriculums = await _curriculumBll.GetEntities(n => n.id > 0).ToListAsync();
            return Content(JsonFactory.Json(curriculums));
        }

        [HttpPost]
        public IActionResult ChooseCurriculumByIdList(List<int> IdList) //学生选择课程，筛选掉重复的，然后添加进学生课程关系表，注意：此时结果是0，需要教师进行同意
        {
            //foreach不用用在字典这里
            //foreach (var k in IdList)
            //{
            //    if (_student__CurriculumBll.GetEntities(u => u.curriculum_id == k && u.student_id == studentId).Count() > 0)
            //    {
            //        IdList.Remove(k);
            //    }
            //}
            for (int i = 0; i < IdList.Count; i++)
            {
                if (_student__CurriculumBll.GetEntities(u => u.curriculum_id == IdList[i] && u.student_id == studentId).Count() > 0)
                {
                    IdList.RemoveAt(i);
                }
            }

            if (IdList.Count == 0)
            {
                return Content(JsonFactory.Json(message: "已重复发送申请！"));
            }

            if (_student__CurriculumBll.AddList(IdList, studentId) > 0)
            {
                return Content(JsonFactory.Json(message: "已发送申请！"));
            }
            else
            {
                return Content(JsonFactory.Json(message: "发送申请失败！",flag:false));
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetTeacherCurriculumLst()//通过登入选择的教师id，得到该名教师的所有课程
        {
          
           var curriculums =await _curriculumBll.GetEntities(u=>u.teacher_id==teacherId).ToListAsync();
            return Content(JsonFactory.Json(curriculums));
        }

        [HttpGet]
        public async Task<IActionResult> TeacherCurriculumApproval()//教师进行对学生申请的课程审批，同意是将结果改成1，0代表待处理，不同意删数据
        {
            //先查询老师有什么课程，再到学生课程关系表中查找
            List<student__curriculum> student__Curriculas = new List<student__curriculum>();
            var curriculums = await _curriculumBll.GetEntities(u => u.teacher_id == teacherId).ToListAsync();
            foreach (var k in curriculums)
            {
                var myData = await _student__CurriculumBll.GetEntities(u => u.curriculum_id == k.id && u.is_result == 0).ToListAsync();
                student__Curriculas = student__Curriculas.Concat(myData).ToList();
            }
            return Content(JsonFactory.Json(student__Curriculas));
        }

        [HttpPost]
        public IActionResult HandleCurriculumByIdList(List<int> IdList,int is_result)//教师进行审批处理
        {
            List<student__curriculum> student__Curriculums = new List<student__curriculum>();
            foreach (var k in IdList)
            {
                student__Curriculums.Add(_student__CurriculumBll.GetEntities(u => u.id == k).FirstOrDefault());
            }
            if (_student__CurriculumBll.UpdateList(student__Curriculums, is_result) > 0)
            {
                return Content(JsonFactory.Json(message: "已成功处理！"));
            }
            else
            {
                return Content(JsonFactory.Json(message: "处理失败！",flag:false));
            }
        }
        [HttpPost]
        [Obsolete]
        public  IActionResult AddCurriculum([FromForm] string curriculum_name,IFormFile logoFile, [FromServices] IHostingEnvironment env)//教师添加课程
        {
            string filename;
            if (logoFile == null)
            {
             filename = "curriculumLogo.jpg";
            }
            else
            { 
            filename = Guid.NewGuid().ToString() + Path.GetExtension(logoFile.FileName);//文件名：唯一标识号.jpg
            }
            string filepub = Path.Combine(env.WebRootPath, "CurriculumLogo", filename);//完整目录
            string fileexit = Path.Combine(env.WebRootPath, "CurriculumLogo");//文件目录名
            if (!Directory.Exists(fileexit))
            {
                Directory.CreateDirectory(fileexit);
            }
            using (var stream = new FileStream(filepub, FileMode.Create))
            {
                logoFile.CopyTo(stream);
            }
            curriculum curriculumData = new curriculum();
            curriculumData.curriculum_name = curriculum_name;
            curriculumData.teacher_id = teacherId;
            curriculumData.createdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            curriculumData.curriculum_logo = filename;
            _curriculumBll.Add(curriculumData);
            return Content(JsonFactory.Json(message:"添加课程成功！"));
        }

        [HttpPost]
        [Obsolete]
        public async Task<IActionResult> UpdateCurriculum([FromForm]int id, [FromForm] string curriculum_name, IFormFile logoFile, [FromServices] IHostingEnvironment env)//教师添加课程
        {
            string filename;
            if (logoFile == null)
            {
                filename = "curriculumLogo.jpg";
            }
            else
            {
                filename = Guid.NewGuid().ToString() + Path.GetExtension(logoFile.FileName);//文件名：唯一标识号.jpg
            }
            string filepub = Path.Combine(env.WebRootPath, "CurriculumLogo", filename);//完整目录
            string fileexit = Path.Combine(env.WebRootPath, "CurriculumLogo");//文件目录名
            if (!Directory.Exists(fileexit))
            {
                Directory.CreateDirectory(fileexit);
            }
            using (var stream = new FileStream(filepub, FileMode.Create))
            {
                logoFile.CopyTo(stream);
            }

            var curriculumData =await _curriculumBll.GetEntities(u => u.id == id).FirstOrDefaultAsync();
            curriculumData.curriculum_name = curriculum_name;
            curriculumData.curriculum_logo = filename;
            _curriculumBll.Update(curriculumData);
            return Content(JsonFactory.Json(message: "修改课程成功！"));
        }
        [HttpGet]
        public async  Task<IActionResult> delCurriculum(int id)
        {
          var studentCurriculumData= await  _student__CurriculumBll.GetEntities(n => n.curriculum_id == id).ToListAsync();
            foreach (var k in studentCurriculumData)
            {
                _student__CurriculumBll.Delete(k);
            }
            if (_curriculumBll.Delete(id))
            {
                return Content(JsonFactory.Json(message: "删除课程成功！"));
            }
            else
            {
                return Content(JsonFactory.Json(flag:false, message: "删除课程失败！"));
            }
        }
    }
}
