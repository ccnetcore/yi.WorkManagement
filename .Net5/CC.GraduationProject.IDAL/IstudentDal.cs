using CC.GraduationProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CC.GraduationProject.IDAL
{
    public partial interface IstudentDal:IBaseDal<student>
    {
        bool Test();
    }
}
