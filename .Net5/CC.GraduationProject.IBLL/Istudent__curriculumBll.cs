using CC.GraduationProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CC.GraduationProject.IBLL
{
    public partial interface Istudent__curriculumBll : IBaseBll<student__curriculum>
    {
        int AddList(List<int> IdList,int studentId);//传入课程id集合和学生id，添加课程学生关系表
        int UpdateList(List<student__curriculum> student__curriculums, int result);//传入课程id集合,教师审批课程
    }
}
