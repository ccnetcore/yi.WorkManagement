using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.GraduationProject.IDAL
{
    public partial interface IDbSession
    {
        int SaveChanges();
    }
  
}
