<template>
  <div id="home">
    <div class="row">
      <div class="col-lg-8" style="padding-right: 0">
        <div class="col-lg-12">
          <div class="shadow myList">
            <div class="row text-center p-4">
              <div class="col-lg-3">
                <p><strong>课程数量</strong></p>
                <el-progress
                  width="100"
                  type="circle"
                  :percentage="25"
                ></el-progress>
                <h2><span>5</span><span class="fz">个</span></h2>
              </div>
              <div class="col-lg-3">
                <p><strong>课程数量</strong></p>
                <el-progress
                  width="100"
                  type="circle"
                  :percentage="50"
                ></el-progress>
                <h2>
                  <span style="color: #2bbf5b">10</span
                  ><span class="fz">个</span>
                </h2>
              </div>
              <div class="col-lg-3">
                <p><strong>课程数量</strong></p>
                <el-progress
                  width="100"
                  type="circle"
                  :percentage="70"
                ></el-progress>
                <h2>
                  <span style="color: #ff7200">22</span
                  ><span class="fz">个</span>
                </h2>
              </div>
              <div class="col-lg-3">
                <p><strong>课程数量</strong></p>
                <el-progress
                  width="100"
                  type="circle"
                  :percentage="90"
                ></el-progress>
                <h2>
                  <span style="color: #e54545">31</span
                  ><span class="fz">个</span>
                </h2>
              </div>
              <div class="col-lg-12">
                <hr style="margin: 0" />
              </div>

              <div class="col-lg-4">
                <p><strong>防护</strong></p>
                <h5><i class="el-icon-circle-check text-success"></i>安全</h5>
              </div>
              <div class="col-lg-4">
                <p><strong>防护</strong></p>
                <h5><i class="el-icon-circle-check text-success"></i>安全</h5>
              </div>
              <div class="col-lg-4">
                <p><strong>防护</strong></p>
                <h5><i class="el-icon-circle-check text-success"></i>安全</h5>
              </div>
            </div>
          </div>
        </div>
        <div class="col-lg-12">
          <div class="shadow myList p-4">
            <v-multipleLine></v-multipleLine>
          </div>
        </div>
        <div class="col-lg-12" >
          <div class="shadow myList p-4" style="height:400px" >
                    <v-pie style="float:left" :mydata="mydata3" w=380 h=380 t="课程统计"></v-pie>
            <v-pie style="float:right" :mydata="mydata4"  w=380 h=380 t="作业统计"></v-pie>
            <div style="float:clear"></div>
             </div>
    </div>

        <div class="col-lg-12">
          <div class="shadow myList p-4" >
            <v-line :mydata="mydata" t="其他统计" ></v-line>
            <v-line :mydata="mydata2" t="其他统计"></v-line>

          </div>
        </div>
      </div>
      <div class="col-lg-4">
        <div class="col-lg-12">
          <div class="shadow myList p-0" >
            <el-calendar  v-model="value"> </el-calendar>
          </div>
        </div>
        <div class="col-lg-12">
          <div class="shadow myList pt-4" style="height: 400px">
           <v-radar w="370" h="400"></v-radar>
          </div>
        </div>
        <div class="col-lg-12">
          <div class="shadow myList" style="height:280px">
            <span class="tit"><strong>热点问题</strong></span>
            <ul id="qList">
              <li><a href="#">茶两种姿态，浮、沉；饮茶人两种姿势，拿起、放下。</a></li>
              <li><a href="#">趁着年轻，你需要多受一些苦，然后才会真正谦恭。</a></li>
              <li><a href="#">人生不仅要学会承受，也要学会释怀。</a></li>
              <li><a href="#">C#是世界上最优雅的语言。</a></li>
              <li><a href="#">那些比你强的人，根本懒得提起你。</a></li>
              <li><a href="#">输出一个Helloword！并且返回一个正确的值。</a></li>
            </ul>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
    <style>
.tit {
  padding-left: 32px;
  line-height: 40px;
}
.fz {
  font-size: 12px;
}
#qList {
  font-size: 12px;
}
#qList li {
  height: 30px;
}
#qList li a {
  color: black;
}

.myList {
  background-color: #ffffff;
  border: darkgray;
  border-radius: 0px !important;
}
#home {
  background-color: #f6f6f6;
  padding-left: 20px;
  padding-right: 20px;
}
.el-calendar-table .el-calendar-day {
        height: 50px !important;
      }
</style>
<script>
import multipleLine from "@/components/echars/multipleLine.vue";
import radar from '@/components/echars/radar.vue'
import line from "@/components/echars/line.vue";
import pie from "@/components/echars/pie";

export default {
  data() {
    return {
      value: new Date(),
      mydata: [12, 25, 35, 46, 23, 53, 75],
      mydata2: [99, 25, 35, 46, 23, 53, 75],
      mydata3: [
        { value: 335, name: "直接访问" },
        { value: 310, name: "邮件营销" },
        { value: 234, name: "联盟广告" },
        { value: 135, name: "视频广告" },
        { value: 1548, name: "搜索引擎" },
      ],
      mydata4: [
        { value: 11, name: "直接访问" },
        { value: 32, name: "邮件营销" },
        { value: 12, name: "联盟广告" },
        { value: 32, name: "视频广告" },
        { value: 42, name: "搜索引擎" },
      ],
            mydata5: [
        { value: 11, name: "直接访问" },
        { value: 32, name: "邮件营销" },
        { value: 12, name: "联盟广告" },
        { value: 32, name: "视频广告" },
        { value: 42, name: "搜索引擎" },
      ],
    };
  },
  components: {
    "v-multipleLine": multipleLine,
    "v-line": line,
    "v-pie": pie,
    "v-radar":radar
  },
};
</script>