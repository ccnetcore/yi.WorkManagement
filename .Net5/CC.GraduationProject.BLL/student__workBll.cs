using CC.GraduationProject.IBLL;
using CC.GraduationProject.IDAL;
using CC.GraduationProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace CC.GraduationProject.BLL
{
    public partial class student__workBll : BaseBll<student__work>, Istudent__workBll
    {
        public bool Add(List<student__work> student__Works)//批量添加的方法
        {
            foreach (var k in student__Works)
            {
                CurrentDal.Add(k);
            }
            return DbSession.SaveChanges() > 0;
        }
    }
}
