using CC.GraduationProject.Common;
using CC.GraduationProject.IBLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.GraduationProject.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class VersionController : BaseController
    {
        private IversionBll _versionBll;
        public VersionController(IversionBll versionBll)
        {
            _versionBll = versionBll;
        }
        [HttpGet]
        public async Task<IActionResult> GetVersionList()
        {
            var versions = await _versionBll.GetEntities(n => n.id > 0).ToListAsync();
            return Content(JsonFactory.Json(versions));
        }
    }
}
