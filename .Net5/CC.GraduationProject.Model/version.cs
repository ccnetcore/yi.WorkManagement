using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CC.GraduationProject.Model
{
    public class version
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "版本号")]
        public string edition { get; set; }

        [Display(Name = "版本内容")]
        public string version_content { get; set; }

        [Display(Name = "更新作者")]
        public string version_author { get; set; }

        [Display(Name = "更新时间")]
        public string version_time { get; set; }
    }
}
