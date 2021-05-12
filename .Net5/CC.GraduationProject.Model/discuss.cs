using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CC.GraduationProject.Model
{
    public class discuss
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "讨论标题")]
        public string discuss_title { get; set; }

        [Display(Name = "讨论内容")]
        public string discuss_content { get; set; }

        [Display(Name = "讨论作者")]
        public string discuss_author { get; set; }

        [Display(Name = "讨论发布时间")]
        public string discuss_createdate { get; set; }

        [Display(Name = "课程id")]
        public int curriculum_id { get; set; }


    }
}
