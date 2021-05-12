using CC.GraduationProject.EFDAL;
using CC.GraduationProject.IDAL;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CC.GraduationProject.DALFactory
{
    public partial class StaticDalFactory
    {
        public static IstudentDal GetstudentDal()
        {
            IstudentDal Data = CallContext.GetData("studentDal") as IstudentDal;
            if (Data == null)
            {
                Data = new studentDal();
                CallContext.SetData("studentDal", Data);
            }
            return Data;
        }

        public static IteacherDal GetteacherDal()
        {
            IteacherDal Data = CallContext.GetData("teacherDal") as IteacherDal;
            if (Data == null)
            {
                Data = new teacherDal();
                CallContext.SetData("teacherDal", Data);
            }
            return Data;
        }

        public static IcommentDal GetcommentDal()
        {
            IcommentDal Data = CallContext.GetData("commentDal") as IcommentDal;
            if (Data == null)
            {
                Data = new commentDal();
                CallContext.SetData("commentDal", Data);
            }
            return Data;
        }

        public static IcurriculumDal GetcurriculumDal()
        {
            IcurriculumDal Data = CallContext.GetData("curriculumDal") as IcurriculumDal;
            if (Data == null)
            {
                Data = new curriculumDal();
                CallContext.SetData("curriculumDal", Data);
            }
            return Data;
        }

        public static IdiscussDal GetdiscussDal()
        {
            IdiscussDal Data = CallContext.GetData("discussDal") as IdiscussDal;
            if (Data == null)
            {
                Data = new discussDal();
                CallContext.SetData("discussDal", Data);
            }
            return Data;
        }

        public static Istudent__curriculumDal Getstudent__curriculumDal()
        {
            Istudent__curriculumDal Data = CallContext.GetData("student__curriculumDal") as Istudent__curriculumDal;
            if (Data == null)
            {
                Data = new student__curriculumDal();
                CallContext.SetData("student__curriculumDal", Data);
            }
            return Data;
        }

        public static Istudent__workDal Getstudent__workDal()
        {
            Istudent__workDal Data = CallContext.GetData("student__workDal") as Istudent__workDal;
            if (Data == null)
            {
                Data = new student__workDal();
                CallContext.SetData("student__workDal", Data);
            }
            return Data;
        }

        public static IworkDal GetworkDal()
        {
            IworkDal Data = CallContext.GetData("workDal") as IworkDal;
            if (Data == null)
            {
                Data = new workDal();
                CallContext.SetData("workDal", Data);
            }
            return Data;
        }

        public static IversionDal GetversionDal()
        {
            IversionDal Data = CallContext.GetData("versionDal") as IversionDal;
            if (Data == null)
            {
                Data = new versionDal();
                CallContext.SetData("versionDal", Data);
            }
            return Data;
        }

        public static Iquestion_choiceDal Getquestion_choiceDal()
        {
            Iquestion_choiceDal Data = CallContext.GetData("question_choiceDal") as Iquestion_choiceDal;
            if (Data == null)
            {
                Data = new question_choiceDal();
                CallContext.SetData("question_choiceDal", Data);
            }
            return Data;
        }

        public static Iquestion_fillDal Getquestion_fillDal()
        {
            Iquestion_fillDal Data = CallContext.GetData("question_fillDal") as Iquestion_fillDal;
            if (Data == null)
            {
                Data = new question_fillDal();
                CallContext.SetData("question_fillDal", Data);
            }
            return Data;
        }

        public static Iquestion_judgmentDal Getquestion_judgmentDal()
        {
            Iquestion_judgmentDal Data = CallContext.GetData("question_judgmentDal") as Iquestion_judgmentDal;
            if (Data == null)
            {
                Data = new question_judgmentDal();
                CallContext.SetData("question_judgmentDal", Data);
            }
            return Data;
        }

    }
}