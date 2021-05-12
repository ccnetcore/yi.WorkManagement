using CC.GraduationProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CC.GraduationProject.IBLL
{ 
    public partial interface IstudentBll:IBaseBll<student>
    {
        int UpdataList(List<student> students);
        bool mytest();
    }

}
