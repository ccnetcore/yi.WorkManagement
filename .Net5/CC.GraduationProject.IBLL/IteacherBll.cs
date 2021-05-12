using CC.GraduationProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CC.GraduationProject.IBLL
{ 
    public partial interface IteacherBll:IBaseBll<teacher>
    {
        int UpdataList(List<teacher> teachers);
    }
}
