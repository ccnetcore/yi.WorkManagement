<template>
  <div class="p-4">
   <h2>关系id：{{ workData.id }}</h2>
              <h2>学生id{{workData.student_id }}</h2>
              <h2>作业id{{ workData.work_id }}</h2>
              <h2>是否完成{{ workData.is_complete }}</h2>
              <h2>完成时间{{ workData.time_complete }}</h2>
              <hr>
    <h4>
      <p><strong>提交作业</strong></p>
    </h4>
    <el-steps :active="active" align-center finish-status="success">
      <el-step title="水印样式"></el-step>
      <el-step title="选择图片"></el-step>
      <el-step title="确定提交"></el-step>
    </el-steps>
    <form class="text-center">
      <div v-show="m1" class="m-4">
        <el-input
          style="width: 60%"
          v-model="usernames"
          placeholder="请输入水印"
          id="name"
        ></el-input>
      </div>

      <div v-show="m2" class="m-4">
        <p>
          <label class="btn btn-primary" for="uploadFile" id="ulf"
            >选择图片</label
          >
        </p>
        <input
          style="display: none"
          type="file"
          id="uploadFile"
          class="clip"
          accept="image/*"
        />
        <div id="imgUploadX"></div>
      </div>
      <div v-show="m3" class="m-4">
        <p>
          <input
            v-show="m3"
            v-on:click="sub()"
            type="button"
            class="btn btn-success"
            value="确认提交"
          />
        </p>
      </div>

      <el-button v-show="su" @click="change" type="primary" round class="m-2">{{
        mesg
      }}</el-button>
    </form>
    <a class="text-info">详细了解</a>
    <hr />
    <el-button @click="lookImage()" type="primary">查看已提交的作业</el-button>
  </div>
</template>
<script>
import itt from '../../../public/js/image'
import workApi from "@/api/work.js";
export default {
  data() {
    return {
      myimgs: "",
      usernames: "",
      adm: false,
      m1: true,
      m2: false,
      m3: false,
      mesg: "下一步",
      active: 0,
      su: true,
      studentworkid: "",
      workData: {},
    };
  },
  created() {
    this.fetchData();
  },
  mounted() {
     this.base_api = process.env.VUE_APP_BASE_API;
    this.usemycore();
  },
  methods: {
    usemycore() {
      var eleUploadFile = document.getElementById("uploadFile");
      var eleImgUploadX = document.getElementById("imgUploadX");
      eleUploadFile.addEventListener("change", function (event) {
        var reader = new FileReader();
        var file = event.target.files[0] || event.dataTransfer.files[0];
        reader.onload = function (e) {
          var base64 = e.target.result;
          // 使用canvas合成图片，并base64化
          itt.imgTogether(base64, function (url) {
            
            eleImgUploadX.innerHTML =
              '<img id="myimg" src="' +
              url +
              '" width="' +
              648 +
              '" height="' +
              1404 +
              '">';
          });
        };
        reader.readAsDataURL(file);
      });
    },
    fetchData() {
      workApi.getWorkByWorkId(this.$route.query.id).then((response) => {
        //获得studentworkid
        const resp = response.data;
        if (resp.flag) {
          this.workData = resp.data;
          this.studentworkid = resp.data.id;
        }
      });
    },
    next() {
      if (this.active++ > 2) this.active = 0;
    },
    change() {
      if (this.m1 == true) {
        this.m1 = false;
        this.m2 = true;
        this.next();
      } else if (this.m2 == true) {
        window.scrollTo(0, 0);
        this.mesg = "最后一步";
        this.m2 = false;
        this.m3 = true;
        this.su = false;
        this.next();
      } else if (this.m3 == true) {
        this.m3 = false;
        this.mesg = "别点了！已经没了！";
      }
    },
    sub() {
      this.m3 = false;
      this.next();
      this.myimgs = document.getElementById("myimg").src;
      const p = workApi.sendImg(this.myimgs,this.studentworkid);
      p.then((response) => {
        const resp = response.data;
        if (resp.flag) {
            this.$router.push({ path: "/index" });
          this.fetchData();

          this.$message({
            type: "success",
            message: resp.message,
          });
        } else {
          this.fetchData();
          this.$message.error("提交失败");
        }
      });
    },
    lookImage()
    {
       var tempwindow = window.open("_blank"); // 先打开页面
      tempwindow.location = this.base_api+"/StudentWorkImages/"+this.workData.student_file_name; // 后更改页面地址
    }
  },

};
</script>
