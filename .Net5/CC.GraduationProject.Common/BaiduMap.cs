using System;
using System.Collections.Generic;
using System.Text;

namespace CC.GraduationProject.Common
{
    public static class BaiduMap
    {
        public static string test="";
        public static MapModle position(string position)
        {
            test += position;
            string ak = "mh9HggnmHRuio4ChLAp4I8FNTCGYVfM2";
            HttpHelper hp = new HttpHelper();
             string mapData=   hp.HttpGet("http://api.map.baidu.com/geocoding/v3/", "address="+ position+"&output=json&ak="+ ak);
            var json = DynamicJson.Parse(mapData);
            MapModle model = new MapModle();

            model.lat = Convert.ToString(json["result"]["location"]["lat"]);
            model.lng = Convert.ToString(json["result"]["location"]["lng"]);
            return model;
        }

    }
    public class MapModle
    {
        public string lng;//经度
        public string lat;//纬度


    }
}