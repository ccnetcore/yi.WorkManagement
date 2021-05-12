using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CC.GraduationProject.Model
{
    public class student__work
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "学生id")]
        public int student_id { get; set; }

        [Display(Name = "作业id")]
        public int work_id { get; set; }

        [Display(Name = "通知结果")]
        public int is_complete { get; set; }

        [Display(Name = "完成时间")]
        public string time_complete { get; set; }

        [Display(Name = "学生作业文件名")]
        public string  student_file_name { get; set; }

        [Display(Name = "学生作业文件路径")]
        public string student_file_route { get; set; }

        [Display(Name = "作业分数")]
        public int work_score { get; set; }

        [Display(Name = "作业评分时间")]
        public string work_score_time { get; set; }
    }
}
