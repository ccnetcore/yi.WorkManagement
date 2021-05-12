using CC.GraduationProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CC.GraduationProject.IDAL
{
    public partial interface IstudentDal:IBaseDal<student>
    {
    }
    public partial interface IteacherDal:IBaseDal<teacher>
    {
    }
    public partial interface IcommentDal:IBaseDal<comment>
    {
    }
    public partial interface IcurriculumDal:IBaseDal<curriculum>
    {
    }
    public partial interface IdiscussDal:IBaseDal<discuss>
    {
    }
    public partial interface Istudent__curriculumDal:IBaseDal<student__curriculum>
    {
    }
    public partial interface Istudent__workDal:IBaseDal<student__work>
    {
    }
    public partial interface IworkDal:IBaseDal<work>
    {
    }
    public partial interface IversionDal:IBaseDal<version>
    {
    }
    public partial interface Iquestion_choiceDal:IBaseDal<question_choice>
    {
    }
    public partial interface Iquestion_fillDal:IBaseDal<question_fill>
    {
    }
    public partial interface Iquestion_judgmentDal:IBaseDal<question_judgment>
    {
    }
}