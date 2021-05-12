using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CC.GraduationProject.Common
{
    public static class JsonFactory
    {
        public static string Json(object data=null,int code=200,bool flag=true,string message="成功")
        {
            return JsonSerializer.Serialize(new { code = code, flag = flag, message = message, data = data }); 
        }
        public static string Json(int num, object data, int code = 200, bool flag = true, string message = "成功")
        {
            return JsonSerializer.Serialize(new { code = code, flag = flag, message = message, data = data, num=num });
        }
        public static string Json(object choice, object judgment , object fill, int code = 200, bool flag = true, string message = "成功")
        {
            return JsonSerializer.Serialize(new { code = code, flag = flag, message = message, choice=choice,judgment=judgment,fill=fill });
        }
        public static string Json(string message2, object data = null, int code = 200, bool flag = true, string message = "成功")
        {
            return JsonSerializer.Serialize(new { code = code, flag = flag, message = message, message2= message2, data = data });
        }
    }
}
