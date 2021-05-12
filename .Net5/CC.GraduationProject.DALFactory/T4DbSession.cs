using CC.GraduationProject.EFDAL;
using CC.GraduationProject.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.GraduationProject.DALFactory
{
public partial class DbSession : IDbSession
    {
        public IstudentDal studentDal
        {
            get { return StaticDalFactory.GetstudentDal(); }
        }

        public IteacherDal teacherDal
        {
            get { return StaticDalFactory.GetteacherDal(); }
        }

        public IcommentDal commentDal
        {
            get { return StaticDalFactory.GetcommentDal(); }
        }

        public IcurriculumDal curriculumDal
        {
            get { return StaticDalFactory.GetcurriculumDal(); }
        }

        public IdiscussDal discussDal
        {
            get { return StaticDalFactory.GetdiscussDal(); }
        }

        public Istudent__curriculumDal student__curriculumDal
        {
            get { return StaticDalFactory.Getstudent__curriculumDal(); }
        }

        public Istudent__workDal student__workDal
        {
            get { return StaticDalFactory.Getstudent__workDal(); }
        }

        public IworkDal workDal
        {
            get { return StaticDalFactory.GetworkDal(); }
        }

        public IversionDal versionDal
        {
            get { return StaticDalFactory.GetversionDal(); }
        }

        public Iquestion_choiceDal question_choiceDal
        {
            get { return StaticDalFactory.Getquestion_choiceDal(); }
        }

        public Iquestion_fillDal question_fillDal
        {
            get { return StaticDalFactory.Getquestion_fillDal(); }
        }

        public Iquestion_judgmentDal question_judgmentDal
        {
            get { return StaticDalFactory.Getquestion_judgmentDal(); }
        }

    }
}