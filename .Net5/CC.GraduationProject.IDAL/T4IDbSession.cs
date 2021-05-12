using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.GraduationProject.IDAL
{
    public partial interface IDbSession
    {
        IstudentDal studentDal { get;}
        IteacherDal teacherDal { get;}
        IcommentDal commentDal { get;}
        IcurriculumDal curriculumDal { get;}
        IdiscussDal discussDal { get;}
        Istudent__curriculumDal student__curriculumDal { get;}
        Istudent__workDal student__workDal { get;}
        IworkDal workDal { get;}
        IversionDal versionDal { get;}
        Iquestion_choiceDal question_choiceDal { get;}
        Iquestion_fillDal question_fillDal { get;}
        Iquestion_judgmentDal question_judgmentDal { get;}
    }
}