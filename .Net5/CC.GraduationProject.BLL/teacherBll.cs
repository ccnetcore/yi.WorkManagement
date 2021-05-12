using CC.GraduationProject.IBLL;
using CC.GraduationProject.IDAL;
using CC.GraduationProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace CC.GraduationProject.BLL
{
    public partial class teacherBll : BaseBll<teacher>,IteacherBll
    {
        #region
        //这里是写的额外方法
        //这里写需要更新的内容
        #endregion
        public int UpdataList(List<teacher> teachers)
        {
            foreach (var stu in teachers)
            {
                //这里写更新内容
                CurrentDal.Update(stu);
  
            }
            return DbSession.SaveChanges();//这里把SaveChanges方法提到了循环体外，自然就与数据库交互一次
        }
    }
}
