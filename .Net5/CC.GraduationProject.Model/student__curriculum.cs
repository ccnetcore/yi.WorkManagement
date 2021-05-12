using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CC.GraduationProject.Model
{
    public class student__curriculum
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "学生id")]
        public int student_id { get; set; }

        [Display(Name = "课程id")]
        public int curriculum_id { get; set; }

        [Display(Name = "通知结果")]
        public int is_result { get; set; }

    }
}
