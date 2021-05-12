using CC.GraduationProject.Common;
using CC.GraduationProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.GraduationProject.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MapController : Controller
    {
        [HttpGet]
        public IActionResult virus()
        {
            HttpHelper httpHelper = new HttpHelper();
            var data = httpHelper.HttpGet("https://interface.sina.cn/news/wap/fymap2020_data.d.json", "");

            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            var json = DynamicJson.Parse(data);
            List<virusModel> models = new List<virusModel>();
            for (int i = 0; i <= 25; i++)
            {
                //if (i == 26||i==28)//百度地图不给台湾、香港等等
                //{
                //    continue;
                //}
                virusModel model = new virusModel();
                model.name = json["data"]["list"][i]["name"];
                model.num =Int32.Parse(json["data"]["list"][i]["value"]);
                models.Add(model);

                MapModle mm = BaiduMap.position(model.name);
                sb.Append("'" + model.name + "':[" + mm.lng + "," + mm.lat + "],");
            }

            sb.Append("}");

            var mysb= JsonConvert.DeserializeObject(sb.ToString());

            return Content(JsonConvert.SerializeObject(new { code = 200, data1 = mysb, data2 = models }));
        }
    }
}
