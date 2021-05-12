using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CC.GraduationProject.Model
{
    public class curriculum
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "课程名字")]
        public string curriculum_name { get; set; }

        [Display(Name = "教师id")]
        public int teacher_id { get; set; }

        [Display(Name = "创建时间")]
        public string createdate { get; set; }

        [Display(Name = "课程图标")]
        public string curriculum_logo { get; set; }

}
}
