<template>
  <div id="home">
    <div class="row">
      <div class="col-lg-8">
        <div class="col-lg-12">
          <div class="shadow myList p-4" style="font-size: 14px">
            <div style="color: #999999">
              <i class="el-icon-warning"></i>嗨！{{
                用户名
              }}欢迎回来！请在这里选择你的课程。
            </div>

            <el-input
              class="my-4"
              placeholder="搜索课程名称（如：计算机）"
              style="width: 100%"
              suffix-icon="el-icon-search"
            ></el-input>
            <p style="font-size: 18px"><strong>我的资源</strong></p>
            <div class="row">
              <div class="col-3 selbox">
                <div style="float: left">
                  <i class="el-icon-help p-1 mr-2"></i>
                </div>
                <div style="float: left">
                  <p>帮助文档</p>
                  <p class="pbox">0次</p>
                </div>
              </div>
              <div class="col-3 selbox">
                <div style="float: left">
                  <i class="el-icon-help p-1 mr-2"></i>
                </div>
                <div style="float: left">
                  <p>帮助文档</p>
                  <p class="pbox">0次</p>
                </div>
              </div>
              <div class="col-3 selbox">
                <div style="float: left">
                  <i class="el-icon-help p-1 mr-2"></i>
                </div>
                <div style="float: left">
                  <p>帮助文档</p>
                  <p class="pbox">0次</p>
                </div>
              </div>
                            <div class="col-3 selbox">
                <div style="float: left">
                  <i class="el-icon-help p-1 mr-2"></i>
                </div>
                <div style="float: left">
                  <p>帮助文档</p>
                  <p class="pbox">0次</p>
                </div>
              </div>
                            <div class="col-3 selbox">
                <div style="float: left">
                  <i class="el-icon-help p-1 mr-2"></i>
                </div>
                <div style="float: left">
                  <p>帮助文档</p>
                  <p class="pbox">0次</p>
                </div>
              </div>
              <div class="col-3 selbox">
                <div style="float: left">
                  <i class="el-icon-help p-1 mr-2"></i>
                </div>
                <div style="float: left">
                  <p>帮助文档</p>
                  <p class="pbox">0次</p>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="col-lg-12">
          <div class="shadow myList p-2">
            <div id="mycur" v-show="nullData">
              这里空空如也！您的课程数量为0哦！请前去申请课程！
            </div>
            <div class="row">
              <div
                class="col-lg-3"
                v-for="(item, i) in curriculumList"
                :key="i"
              >
                <el-card :body-style="{ padding: '0px' }">
                  <img
                  :src="getImgUrl(item.curriculum_logo)"
                    class="image"
                  />
                  <div style="padding: 14px">
                    <span>{{ item.curriculum_name }}</span>
                    <div class="bottom clearfix">
                      <time class="time">{{ item.createdate }}</time>
                      <el-button
                        type="text"
                        class="button"
                        @click="intoWork(item.id)"
                        >进入</el-button
                      >
                    </div>
                  </div>
                </el-card>
              </div>
            </div>
          </div>
        </div>

      </div>
      <div class="col-lg-4">
        <div class="col-lg-12">
          <div class="shadow myList p-4" >
            <div class="row">
              <div class="col-lg-3">
                <el-avatar style="background-color: #006eff" :size="70">
                  user
                </el-avatar>
              </div>
              <div class="col-lg-3">
                <p>测试员</p>
                <p class="font1">账户ID</p>
                <p class="font1">其他信息</p>
              </div>
              <div class="col-lg-6">
                <p style="margin: 40px"></p>
                <p class="font1" style="color: #000000">123456</p>
                <p class="font1">654321</p>
              </div>
            </div>
            <div class="my-4">
              <span
                ><strong>访问管理</strong>
                <span
                  ><el-link  style="float: right;margin-right:36px" type="primary"
                    >其他信息</el-link
                  ></span
                >
                </span
              >
            </div>
            <div class="row">
              <div class="col-lg-4 selbox2">
                <p class="font1">用户数</p>
                <p>0</p>
              </div>
              <div class="col-lg-4 selbox2">
                <p class="font1">用户组</p>
                <p>0</p>
              </div>
              <div class="col-lg-4 selbox2">
                <p class="font1">角色</p>
                <p>0</p>
              </div>
            </div>
            <div id="bottdiv">
             <p> <i style="color:#006EFF;font-size:18px" class="el-icon-warning-outline"></i>你还想查看更多？点击这里</p>
            </div>
          </div>
        </div>
        <div class="col-lg-12">
          <div class="shadow myList" ><v-pie :mydata="mydata" w=350 h=380 t="课程统计"></v-pie></div>
        </div>
      </div>
    </div>
  </div>
</template>
    <style>
.myList {
  background-color: #ffffff;
  border: darkgray;
  border-radius: 0px  !important;
  padding: 10px;
}
#home {
  background-color: #f6f6f6;
  padding-left: 20px;
  padding-right: 20px;
}

.time {
  font-size: 13px;
  color: #999;
}

.bottom {
  margin-top: 13px;
  line-height: 12px;
}

.button {
  padding: 0;
  float: right;
}

.image {
  width: 100%;
  display: block;
}

.clearfix:before,
.clearfix:after {
  display: table;
  content: "";
}

.clearfix:after {
  clear: both;
}
.selbox:hover {
  color: #006eff;
  cursor: pointer;
}
.selbox i {
  font-size: 50px;
  background-color: #f3f6fb;
  color: #7c8481;
}
.pbox {
  font-size: 12px;
  color: #7c8481;
}
#mycur {
  height: 200px;
  text-align: center;
  line-height: 150px;
}
.font1 {
  font-size: 12px;
  color: #999999;
}
#bottdiv{
  height: 50px;
  background-color: #D5E7FF;
  font-size: 12px;
  color: #002Da0;
  text-align: center;
  line-height: 50px;
}
</style>
<script>
$(function () {
  $(".selbox").mouseenter(function () {
    $(this).find("i").css("background-color", "#ebf4ff");
  });
  $(".selbox").mouseleave(function () {
    $(this).find("i").css("background-color", "#f3f6fb");
  });
  $(".selbox2").mouseenter(function () {
    $(this).css("background-color", "#f3f6fb");
  });
  $(".selbox2").mouseleave(function () {
    $(this).css("background-color", "#ffffff");
  });
});
import pie from "@/components/echars/pie";
import curriculumApi from "@/api/curriculum.js";
export default {
    components: {

    "v-pie": pie,

  },
  data() {
    return {
      curriculumList: [],
      nullData: true,
            mydata: [
        { value: 335, name: "直接访问" },
        { value: 310, name: "邮件营销" },
        { value: 234, name: "联盟广告" },
        { value: 135, name: "视频广告" },
        { value: 1548, name: "搜索引擎" },
      ],
    };
  },
  created() {
    this.fetchData();
  },
    mounted() {
    this.base_api = process.env.VUE_APP_BASE_API;
  },
  methods: {
    getImgUrl(filename){
  return this.base_api+"/CurriculumLogo/"+filename
},
    intoWork(CurriculumId) {
      this.$router.push({ path: "/allWork", query: { id: CurriculumId } });
    },
    fetchData() {
      curriculumApi.getStudentCurriculumList().then((response) => {
        const resp = response.data;
        if (resp.flag) {
          this.curriculumList = resp.data;
          if (this.curriculumList != null) {
            this.nullData = false;
       
          }
        }
      });
    },
  },
};
</script>
