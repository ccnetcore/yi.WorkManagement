using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CC.GraduationProject.Model
{
    public class question_judgment
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "题目")]
        public string subject { get; set; }

        [Display(Name = "正确选项")]
        public char? option_correct { get; set; }

        [Display(Name = "被选择的选项")]
        public char? option_select { get; set; }

        [Display(Name = "作业Id")]
        public int work_id { get; set; }
    }
}
