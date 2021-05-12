using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CC.GraduationProject.Model
{
    public class teacher
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "教师工号")]
        public string teacher_number { get; set; }

        [Display(Name = "教师姓名")]
        public string teacher_name { get; set; }

        [Display(Name = "教师单位")]
        public string teacher_company { get; set; }

        [Display(Name = "教师电话")]
        public string teacher_phone { get; set; }

        [Display(Name = "教师用户名")]
        public string teacher_username { get; set; }

        [Display(Name = "教师密码")]
        public string teacher_password { get; set; }
    }
}
