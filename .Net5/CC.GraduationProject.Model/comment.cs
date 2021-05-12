using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CC.GraduationProject.Model
{
   public  class comment
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "讨论id")]
        public int discuss_id { get; set; }

        [Display(Name = "评论内容")]
        public string comment_content { get; set; }

        [Display(Name = "评论作者")]
        public string comment_author { get; set; }

        [Display(Name = "评论发布时间")]
        public string comment_createdate { get; set; }

    }
}
