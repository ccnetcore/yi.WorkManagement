using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CC.GraduationProject.Model
{
    public class student
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "学生学号")]
        public string student_number { get; set; }

        [Display(Name = "学生姓名")]
        public string student_name { get; set; }

        [Display(Name = "学生班级")]
        public string student_class { get; set; }

        [Display(Name = "学生年龄")]
        public int student_age { get; set; }

        [Display(Name = "学生邮箱")]
        public string student_mailbox { get; set; }

        [Display(Name = "学生电话")]
        public string student_phone { get; set; }

        [Display(Name = "学生用户名")]
        public string student_username { get; set; }

        [Display(Name = "学生密码")]
        public string student_password { get; set; }
    }
}
