<template>
  <div id="home">
    <div class="row">
      <div class="col-lg-8" style="padding-right: 0">
        <div class="col-lg-12">
          <div class="shadow myList p-2">
            <el-divider content-position="left">作业信息</el-divider>
            <h2>关系id：{{ workList.id }}</h2>
            <h2>学生id：{{ workList.student_id }}</h2>
            <h2>作业id：{{ workList.work_id }}</h2>
            <h2>是否完成：{{ workList.is_complete }}</h2>
            <h2>完成时间：{{ workList.time_complete }}</h2>
          </div>
        </div>
        <div class="col-lg-12">
          <div class="shadow myList p-4">
            <el-divider content-position="left">查看作业</el-divider>
            <el-form>
              <el-form-item label="查看教师布置作业:">
                <el-button
                  size="small"
                  type="primary"
                  @click="openTeacherWork()"
                  >查看</el-button
                >
              </el-form-item>
              <el-form-item label="查看已提交的作业:">
                <el-button size="small" type="primary" @click="openWork()"
                  >查看</el-button
                >
              </el-form-item>
            </el-form>
          </div>
        </div>
        <div class="col-lg-12">
          <div class="shadow myList">
            <el-form :model="form" status-icon ref="form">
              <el-row type="flex" justify="center">
                <el-col :span="22">
                  <el-divider content-position="left">提交作业</el-divider>
                  <el-form-item label="选择提交作业文件:">
                    <el-upload
                      name="formFile"
                      class="upload-demo"
                      ref="upload"
                      :with-credentials="true"
                      :limit="1"
                      :file-list="fileList"
                      :action="uploadUrl()"
                      :on-change="addFile"
                      :on-success="successResp"
                      :auto-upload="false"
                      :data="this.form"
                    >
                      <el-button size="small" type="primary">选择</el-button>
                    </el-upload>
                  </el-form-item>
                </el-col>
              </el-row>
            </el-form>
            <div slot="footer" class="dialog-footer p-4">
              <el-button type="success" @click="insert('form')"
                >确认提交</el-button
              >
            </div>
          </div>
        </div>
      </div>
      <div class="col-lg-4">
        <div class="col-lg-12">
          <div class="shadow myList" style="height: 400px"></div>
        </div>
        <div class="col-lg-12">
          <div class="shadow myList" style="height: 600px"></div>
        </div>
      </div>
    </div>
  </div>
</template>
    <style>
.myList {
  background-color: #ffffff;
  border: darkgray;
  border-radius: 5px;
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
.el-upload-list{
  height: 10px;
}
</style>
<script>
import workApi from "@/api/work.js";
export default {
  data() {
    return {
      workList: {},
      form: {
        work_id: this.$route.query.id,
      },
    };
  },
  mounted() {
    this.base_api = process.env.VUE_APP_BASE_API;
  },
  created() {
    this.fetchData();
  },
  methods: {
    openTeacherWork() {
      workApi.getMyWorkByWorkId(this.workList.work_id).then((response) => {
        const resp = response.data;
        const name = resp.data.work_file_name;
        var tempwindow = window.open("_blank"); // 先打开页面
        tempwindow.location = this.base_api + "/WorkFiles/" + name; // 后更改页面地址
      });
    },
    insert(formName) {
      this.$refs[formName].validate((valid) => {
        if (valid) {
          // if(this.fileList.length <= 0){
          //     this.$message.error("请至少上传一个文件！");
          //     return;
          // }
          // if(!this.fileSizeIsSatisfy){
          //     this.$message.error("上传失败！存在文件大小超过5M！");
          //     return;
          // }
          //手动上传文件，在点击确认的时候 校验通过才会去请求上传文件的url
          this.$refs.upload.submit();

          this.$message({
            type: "success",
            message: "作业提交成功！",
          });
        }
      });
    },
    uploadUrl: function () {
      return this.base_api + "/work/AddStudentWork";
    },
    openWork() {
      var tempwindow = window.open("_blank"); // 先打开页面
      tempwindow.location =
        this.base_api + "/StudentWorkFiles/" + this.workList.student_file_name; // 后更改页面地址
      //  this.$router.push({ path: "/examinationInfo", query: {studentworkid:this.workList.id} });
    },
    fetchData() {
      workApi.getWorkByWorkId(this.$route.query.id).then((response) => {
        const resp = response.data;
        if (resp.flag) {
          this.workList = resp.data;
        }
      });
    },
  },
};
</script>
