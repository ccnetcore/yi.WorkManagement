using CC.GraduationProject.IBLL;
using CC.GraduationProject.IDAL;
using CC.GraduationProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.GraduationProject.BLL
{
public partial class studentBll : BaseBll<student>, IstudentBll
    {
        public studentBll(IBaseDal<student> cd):base(cd)
        {
            CurrentDal = cd;
        }
    }
public partial class teacherBll : BaseBll<teacher>, IteacherBll
    {
        public teacherBll(IBaseDal<teacher> cd):base(cd)
        {
            CurrentDal = cd;
        }
    }
public partial class commentBll : BaseBll<comment>, IcommentBll
    {
        public commentBll(IBaseDal<comment> cd):base(cd)
        {
            CurrentDal = cd;
        }
    }
public partial class curriculumBll : BaseBll<curriculum>, IcurriculumBll
    {
        public curriculumBll(IBaseDal<curriculum> cd):base(cd)
        {
            CurrentDal = cd;
        }
    }
public partial class discussBll : BaseBll<discuss>, IdiscussBll
    {
        public discussBll(IBaseDal<discuss> cd):base(cd)
        {
            CurrentDal = cd;
        }
    }
public partial class student__curriculumBll : BaseBll<student__curriculum>, Istudent__curriculumBll
    {
        public student__curriculumBll(IBaseDal<student__curriculum> cd):base(cd)
        {
            CurrentDal = cd;
        }
    }
public partial class student__workBll : BaseBll<student__work>, Istudent__workBll
    {
        public student__workBll(IBaseDal<student__work> cd):base(cd)
        {
            CurrentDal = cd;
        }
    }
public partial class workBll : BaseBll<work>, IworkBll
    {
        public workBll(IBaseDal<work> cd):base(cd)
        {
            CurrentDal = cd;
        }
    }
public partial class versionBll : BaseBll<version>, IversionBll
    {
        public versionBll(IBaseDal<version> cd):base(cd)
        {
            CurrentDal = cd;
        }
    }
public partial class question_choiceBll : BaseBll<question_choice>, Iquestion_choiceBll
    {
        public question_choiceBll(IBaseDal<question_choice> cd):base(cd)
        {
            CurrentDal = cd;
        }
    }
public partial class question_fillBll : BaseBll<question_fill>, Iquestion_fillBll
    {
        public question_fillBll(IBaseDal<question_fill> cd):base(cd)
        {
            CurrentDal = cd;
        }
    }
public partial class question_judgmentBll : BaseBll<question_judgment>, Iquestion_judgmentBll
    {
        public question_judgmentBll(IBaseDal<question_judgment> cd):base(cd)
        {
            CurrentDal = cd;
        }
    }
}