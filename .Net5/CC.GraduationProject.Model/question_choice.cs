using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CC.GraduationProject.Model
{
    public class question_choice
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "题目")]
        public string subject { get; set; }

        [Display(Name = "选项A")]
        public string option_a { get; set; }

        [Display(Name = "选项B")]
        public string option_b { get; set; }

        [Display(Name = "选项C")]
        public string option_c { get; set; }

        [Display(Name = "选项D")]
        public string option_d { get; set; }

        [Display(Name = "正确选项")]
        public char? option_correct { get; set; }

        [Display(Name = "被选择的选项")]
        public char? option_select { get; set; }

        [Display(Name = "作业Id")]
        public int work_id { get; set; }
    }
}
