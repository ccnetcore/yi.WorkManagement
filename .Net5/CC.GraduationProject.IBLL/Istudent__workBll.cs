using CC.GraduationProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CC.GraduationProject.IBLL
{
   public partial interface Istudent__workBll : IBaseBll<student__work>
    {
        bool Add(List<student__work> student__Works);//批量添加的方法
    }
}
