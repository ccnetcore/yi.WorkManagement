using CC.GraduationProject.Common;
using CC.GraduationProject.IBLL;
using CC.GraduationProject.Model;
using CC.GraduationProject.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CC.GraduationProject.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class WorkController : BaseController
    {
        private IworkBll _workBll;
        private Istudent__workBll _student__WorkBll;
        private Istudent__curriculumBll _student__CurriculumBll;
        public WorkController(IworkBll workBll, Istudent__workBll student__WorkBll, Istudent__curriculumBll student__CurriculumBll, IcurriculumBll curriculumBll)
        {
            _workBll = workBll;
            _student__WorkBll = student__WorkBll;
            _student__CurriculumBll = student__CurriculumBll;
        }
        [HttpGet]
        public async Task<IActionResult> GetWorklistByCurriculumId(int curriculumId)//传入课程id得到作业集合
        {
            var works = await _workBll.GetEntities(u => u.curriculum_id == curriculumId).ToListAsync();
            return Content(JsonFactory.Json(works));
        }
        [HttpGet]
        public async Task<IActionResult> GetWorkByWorkId(int workId)//传入作业id，学生具体完成作业
        {
            var student_works = await _student__WorkBll.GetEntities(u => u.work_id == workId).FirstOrDefaultAsync();
            return Content(JsonFactory.Json(student_works));
        }
        [HttpPost]
        [Obsolete]
        public IActionResult AddWork([FromServices] IHostingEnvironment env, IFormFile formFile, [FromForm] string work_name, [FromForm] string time_start, [FromForm] string time_end, [FromForm] int curriculum_id, [FromForm] int work_type)//教师添加作业
        {
            string filename = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
            string filepub = Path.Combine(env.WebRootPath, "WorkFiles", filename);//完整目录
            string fileexit = Path.Combine(env.WebRootPath, "WorkFiles");//文件目录名
            if (!Directory.Exists(fileexit))
            {
                Directory.CreateDirectory(fileexit);
            }
            using (var stream = new FileStream(filepub, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }
            work workData = new work();
            workData.curriculum_id = curriculum_id;
            workData.work_name = work_name;
            workData.time_start = time_start;
            workData.time_end = time_end;
            workData.teacher_id = teacherId;
            workData.work_file_name = filename;
            workData.work_file_route = filepub;
            workData.work_type = work_type;
            var workDataResult = _workBll.Add(workData);//将作业添加到作业表中
                                                        //要想添加学生课程关系表的话，需要知道学生id，学生id通过该课程id来查找

            var student__Curriculums = _student__CurriculumBll.GetEntities(n => n.curriculum_id == workDataResult.curriculum_id).ToList();
            List<student__work> student__Works = new List<student__work>();
            foreach (var k in student__Curriculums)
            {
                student__work student__WorkData = new student__work();
                student__WorkData.is_complete = 0;
                student__WorkData.time_complete = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                student__WorkData.student_id = k.student_id;
                student__WorkData.work_id = workDataResult.id;
                student__WorkData.work_score = -1;
                student__Works.Add(student__WorkData);
            }

            _student__WorkBll.Add(student__Works);

            return Content(JsonFactory.Json(message: "作业添加成功！所有课程下的学生已发布作业！"));
        }
        [HttpPost]
        [Obsolete]
        public IActionResult AddStudentWork([FromServices] IHostingEnvironment env, IFormFile formFile, [FromForm] int work_id)
        {
            if (formFile != null)
            {
                string filename = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);//文件名：唯一标识号.jpg
                string filepub = Path.Combine(env.WebRootPath, "StudentWorkFiles", filename);//完整目录
                string fileexit = Path.Combine(env.WebRootPath, "StudentWorkFiles");//文件目录名
                if (!Directory.Exists(fileexit))
                {
                    Directory.CreateDirectory(fileexit);
                }
                using (var stream = new FileStream(filepub, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }

                var data = _student__WorkBll.GetEntities(u => u.student_id == studentId && u.work_id == work_id).FirstOrDefault();
                data.is_complete = 1;
                data.time_complete = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                data.student_file_name = filename;
                data.student_file_route = filepub;
                if (_student__WorkBll.Update(data))
                {
                    return Content(JsonFactory.Json(message: "提交作业成功！"));
                }
            }
            return Content(JsonFactory.Json(flag: false, message: "提交作业失败！请联系管理员"));
        }
        [HttpGet]
        public async Task<IActionResult> GetApprovalWorkList()//得到改名教师审批作业表
        {
            var works = await _workBll.GetEntities(n => n.teacher_id == teacherId).ToListAsync();
            List<student__work> student__works = new List<student__work>();
            foreach (var k in works)
            {
                var mydata = await _student__WorkBll.GetEntities(n => n.is_complete == 1 && n.work_score == -1 && n.work_id == k.id).FirstOrDefaultAsync();
                if (mydata == null)
                {
                    continue;
                }
                student__works.Add(mydata);
            }
            return Content(JsonFactory.Json(student__works));
        }
        [HttpPost]
        public async Task<IActionResult> ApprovalWork([FromForm] int studentworkId, [FromForm] int score)//教师将已经完成的作业进行评分
        {
            if (score >= 0 && score <= 100)
            {
                var workData = await _student__WorkBll.GetEntities(n => n.id == studentworkId).FirstOrDefaultAsync();
                workData.work_score = score;
                workData.work_score_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                if (_student__WorkBll.Update(workData))
                {
                    return Content(JsonFactory.Json(message: "已成功批改作业！"));
                }
            }
            return Content(JsonFactory.Json(flag: false, message: "批改作业失败！"));
        }
        [HttpPost]
        public async Task<IActionResult> GetStudentWorkList([FromForm] int page, [FromForm] int size, [FromForm] bool by)//通过学生id来得到学生需要的作业
        {
            var student_works = await _student__WorkBll.GetPageEntities(size, page, out int total, u => u.student_id == studentId, o => o.id, by).ToListAsync();
            return Content(JsonFactory.Json(num: total, data: student_works));

        }
        [HttpGet]
        public async Task<IActionResult> GetWorkTypeByWorkId(int workId)//通过workid获取work类型
        {
            var studentworkData = await _workBll.GetEntities(u => u.id == workId).FirstOrDefaultAsync();
            return Content(JsonFactory.Json(studentworkData.work_type));
        }
        [HttpPost]
        public IActionResult AddWorkByAjax(work workData)
        {
            workData.teacher_id = teacherId;
            var data = _workBll.Add(workData);
            var student__Curriculums = _student__CurriculumBll.GetEntities(n => n.curriculum_id == workData.curriculum_id).ToList();
            List<student__work> student__Works = new List<student__work>();
            foreach (var k in student__Curriculums)
            {
                student__work student__WorkData = new student__work();
                student__WorkData.is_complete = 0;
                student__WorkData.time_complete = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                student__WorkData.work_score_time = student__WorkData.time_complete;
                student__WorkData.student_id = k.student_id;
                student__WorkData.work_id = workData.id;
                student__WorkData.work_score = -1;
                student__Works.Add(student__WorkData);
            }

            _student__WorkBll.Add(student__Works);
            return Content(JsonFactory.Json(data.id));
        }
        [HttpPost]
        public async Task<IActionResult> sendImg([FromForm] string myimg, [FromForm] int id)
        {
            if (myimg != null)
            {
               string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string filename = Guid.NewGuid().ToString();
                var student_workData = await _student__WorkBll.GetEntities(n => n.id == id).FirstOrDefaultAsync();
                student_workData.is_complete = 1;
                student_workData.student_file_name = filename + ".jpg";
                student_workData.time_complete = dateTime;
                student_workData.work_score = 100;
                student_workData.work_score_time = dateTime;
                Common.SaveImage.ByStringToSave(filename, myimg); 
                //if (System.IO.File.Exists("./wwwroot/StudentImage1/陈淳.jpg"))
                //    if (Common.SaveImage.Compare("./wwwroot/StudentImage/" + name + ".jpg", "./wwwroot/StudentImage/陈淳.jpg") > 20)
                //    {
                //        diffImg = "2";
                //    }
                _student__WorkBll.Update(student_workData);
                return Content(JsonFactory.Json(message: "作业提交成功！"));
            }
            else
            {
                return Content(JsonFactory.Json(flag: false, message: "作业提交失败！"));
            }

        }
        [HttpPost]
        public async Task<IActionResult> updateWork(work workData)
        {
            var myData = await _workBll.GetEntities(n => n.id == workData.id).FirstOrDefaultAsync();
            myData.time_start = workData.time_start;
            myData.time_end = workData.time_end;
            myData.work_name = workData.work_name;
            if (_workBll.Update(myData))
            {
                return Content(JsonFactory.Json(message: "修改成功!"));
            }
            else
            {
                return Content(JsonFactory.Json(flag: false, message: "修改失败!"));
            }
        }
        [HttpGet]
        public async Task<IActionResult> delWorkByWorkId(int workId)
        {
            var studentWorkList = await _student__WorkBll.GetEntities(u => u.work_id == workId).ToListAsync();
            foreach (var k in studentWorkList)
            {
                _student__WorkBll.Delete(k);
            }
            if (_workBll.Delete(workId))
            {

                return Content(JsonFactory.Json(message: "删除成功!"));
            }
            else
            {
                return Content(JsonFactory.Json(flag: false, message: "删除失败!"));
            }
        }
        [HttpGet]
        public async Task<IActionResult> getMyWorkByWorkId(int workId)
        {
            var workData = await _workBll.GetEntities(n => n.id == workId).FirstOrDefaultAsync();
            return Content(JsonFactory.Json(workData));
        }
        [HttpGet]
        public IActionResult getWorkGroup()
        {
            int y = _student__WorkBll.GetCount(u => u.is_complete == 1);
            int n = _student__WorkBll.GetCount(u => u.is_complete == 0);
            List<workPie> Data = new List<workPie>();

            Data.Add(new workPie { value = y, name = "已完成" });
            Data.Add(new workPie { value = n, name = "已完成" });

            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(new {code=200,flag=true,data=  Data }));
        }

    }
}
