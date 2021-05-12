using CC.GraduationProject.IDAL;
using CC.GraduationProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CC.GraduationProject.EFDAL
{
    public partial class studentDal : BaseDal<student>, IstudentDal
    {
    }
    public partial class teacherDal : BaseDal<teacher>, IteacherDal
    {
    }
    public partial class commentDal : BaseDal<comment>, IcommentDal
    {
    }
    public partial class curriculumDal : BaseDal<curriculum>, IcurriculumDal
    {
    }
    public partial class discussDal : BaseDal<discuss>, IdiscussDal
    {
    }
    public partial class student__curriculumDal : BaseDal<student__curriculum>, Istudent__curriculumDal
    {
    }
    public partial class student__workDal : BaseDal<student__work>, Istudent__workDal
    {
    }
    public partial class workDal : BaseDal<work>, IworkDal
    {
    }
    public partial class versionDal : BaseDal<version>, IversionDal
    {
    }
    public partial class question_choiceDal : BaseDal<question_choice>, Iquestion_choiceDal
    {
    }
    public partial class question_fillDal : BaseDal<question_fill>, Iquestion_fillDal
    {
    }
    public partial class question_judgmentDal : BaseDal<question_judgment>, Iquestion_judgmentDal
    {
    }
}