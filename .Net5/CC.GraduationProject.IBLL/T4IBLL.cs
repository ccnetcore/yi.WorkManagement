using CC.GraduationProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CC.GraduationProject.IBLL
{
   public partial interface IstudentBll : IBaseBll<student>
    {
    }
   public partial interface IteacherBll : IBaseBll<teacher>
    {
    }
   public partial interface IcommentBll : IBaseBll<comment>
    {
    }
   public partial interface IcurriculumBll : IBaseBll<curriculum>
    {
    }
   public partial interface IdiscussBll : IBaseBll<discuss>
    {
    }
   public partial interface Istudent__curriculumBll : IBaseBll<student__curriculum>
    {
    }
   public partial interface Istudent__workBll : IBaseBll<student__work>
    {
    }
   public partial interface IworkBll : IBaseBll<work>
    {
    }
   public partial interface IversionBll : IBaseBll<version>
    {
    }
   public partial interface Iquestion_choiceBll : IBaseBll<question_choice>
    {
    }
   public partial interface Iquestion_fillBll : IBaseBll<question_fill>
    {
    }
   public partial interface Iquestion_judgmentBll : IBaseBll<question_judgment>
    {
    }
}