using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CC.GraduationProject.Model
{
    public class work
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "课程号")]
        public int curriculum_id { get; set; }

        [Display(Name = "教师工号")]
        public int teacher_id { get; set; }

        [Display(Name = "开始时间")]
        public string time_start { get; set; }

        [Display(Name = "结束时间")]
        public string time_end { get; set; }

        [Display(Name = "作业名称")]
        public string work_name { get; set; }

        [Display(Name = "作业文件名称")]
        public string work_file_name { get; set; }
        [Display(Name = "作业文件路径")]
        public string work_file_route { get; set; }
        [Display(Name = "作业类型")]//1代表文件，2代表试卷
        public int work_type { get; set; }
    }
}
