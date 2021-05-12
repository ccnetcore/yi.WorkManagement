using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CC.GraduationProject.IBLL;
using Microsoft.EntityFrameworkCore;
using CC.GraduationProject.Common;
using CC.GraduationProject.Model;
using Microsoft.AspNetCore.Http;

namespace CC.GraduationProject.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ExaminationController : BaseController
    {
        private Iquestion_choiceBll _question_choiceBll;
        private Iquestion_judgmentBll _question_judgmentBll;
        private Iquestion_fillBll _question_fillBll;
        private Istudent__workBll _student__WorkBll;
        public ExaminationController(Iquestion_choiceBll question_choiceBll,Iquestion_judgmentBll question_judgmentBll,Iquestion_fillBll question_fillBll, Istudent__workBll student__WorkBll)
        {
            _question_choiceBll = question_choiceBll;
            _question_judgmentBll = question_judgmentBll;
            _question_fillBll = question_fillBll;
            _student__WorkBll = student__WorkBll;
        }
        [HttpGet]
        public async Task<IActionResult> getExaminationList(int workid)
        {
            var choices = await _question_choiceBll.GetEntities(n => n.work_id == workid).ToListAsync();
            var judgments=await _question_judgmentBll.GetEntities(n => n.work_id == workid).ToListAsync();
            var fills= await _question_fillBll.GetEntities(n => n.work_id == workid).ToListAsync();
            return Content(JsonFactory.Json(choice: choices, judgment: judgments, fill: fills));
        }
        [HttpPost]
        public async Task<IActionResult> subExamination1(List<question_choice> choice_questionList)
        {
            int score = 0;
            foreach (var k in choice_questionList)
            {
                var choiceData = await _question_choiceBll.GetEntities(n => n.id == k.id).FirstOrDefaultAsync();
                if (choiceData.option_correct == k.option_select)
                {
                    score += 2;
                }
            }
            HttpContext.Session.SetString("score", score.ToString());
            return Content(JsonFactory.Json(message:"ok"));
        }
        [HttpPost]
        public async Task<IActionResult> subExamination2(List<question_judgment> judgment_questionList)
        {
            int score=Convert.ToInt32( HttpContext.Session.GetString("score"));
            foreach (var k in judgment_questionList)
            {
                var judgmentData = await _question_judgmentBll.GetEntities(n => n.id == k.id).FirstOrDefaultAsync();
                if (judgmentData.option_correct == k.option_select)
                {
                    score += 1;
                }
            }
            HttpContext.Session.SetString("score", score.ToString());
            return Content(JsonFactory.Json(message: "ok"));
        }
        [HttpPost]
        public async Task<IActionResult> subExamination3(List<question_fill> fill_questionList,int studentworkId)
        {
            int score = Convert.ToInt32(HttpContext.Session.GetString("score"));
            foreach (var k in fill_questionList)
            {
                var fillData = await _question_fillBll.GetEntities(n => n.id == k.id).FirstOrDefaultAsync();
                if (fillData.option_correct == k.option_input)
                {
                    score += 3;
                }
            }
            HttpContext.Session.SetString("score", "0");
            //这里是修改分数，可以转移到其他控制器
            

            if (score >= 0 && score <= 100)
            {
                var workData = await _student__WorkBll.GetEntities(n => n.id == studentworkId).FirstOrDefaultAsync();
                workData.work_score = score;
                workData.work_score_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                workData.is_complete = 1;
                workData.time_complete = workData.work_score_time;
                if (_student__WorkBll.Update(workData))
                {
                    return Content(JsonFactory.Json(message: "你的分数为：" + score.ToString()));
                }
            }
            return Content(JsonFactory.Json(flag:false));
        }
        [HttpPost]
        public IActionResult addExamination1(List<question_choice> Data)
        {
            foreach (var k in Data)
            {
                _question_choiceBll.Add(k);
            }
           
            return Content(JsonFactory.Json());
        }
        [HttpPost]
        public IActionResult addExamination2(List<question_judgment> Data)
        {
            foreach(var k in Data)
            { 
            _question_judgmentBll.Add(k);
            }
            return Content(JsonFactory.Json());
        }
        [HttpPost]
        public IActionResult addExamination3(List<question_fill> Data)
        {
            foreach (var k in Data)
            {
                _question_fillBll.Add(k);
            }
            return Content(JsonFactory.Json(message:"添加成功"));
        }
    }
}
