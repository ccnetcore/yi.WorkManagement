using CC.GraduationProject.IBLL;
using CC.GraduationProject.IDAL;
using CC.GraduationProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CC.GraduationProject.BLL
{
    public partial class student__curriculumBll : BaseBll<student__curriculum>, Istudent__curriculumBll
    {

        public int AddList(List<int> IdList, int studentId)//传入课程id集合和学生id，添加课程学生关系表
        {
            foreach (var k in IdList)
            {
                student__curriculum data = new student__curriculum();
                data.curriculum_id = k;
                data.student_id = studentId;
                data.is_result = 0;
                CurrentDal.Add(data);
            }
            return DbSession.SaveChanges();
        }
        public int UpdateList(List<student__curriculum> student__curriculums,  int result)//传入课程id集合,教师审批课程
        {
            switch (result)
            {
                case 1://同意，将结果修改成1
                    foreach (var k in student__curriculums)
                    {
                        k.is_result = 1;
                        CurrentDal.Update(k);  
                    }
                    return DbSession.SaveChanges();
                case 0://不同意，将数据删除
                    foreach (var k in student__curriculums)
                    {
                        CurrentDal.Delete(k);
                    }
                    return DbSession.SaveChanges();
               default:return 0;
            }
        }
    }
}
