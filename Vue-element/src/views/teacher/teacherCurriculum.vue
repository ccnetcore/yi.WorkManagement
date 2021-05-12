<template>
  <!-- @click="intoMyWork(item.id)" -->
  <div id="home">
    <div class="row">
      <div class="col-lg-8" style="padding-right: 0">
        <div class="col-lg-12">
          <div class="shadow myList p-2" style="height: 200px">
            这里放一些老师的数据
          </div>
        </div>
        <div class="col-lg-12">
          <div class="shadow myList p-2">
            <div class="row">
              <div
                class="col-lg-3"
                v-for="(item, i) in curriculumList"
                :key="i"
              >
                <el-card :body-style="{ padding: '0px' }">
                  <img :src="getImgUrl(item.curriculum_logo)" class="image" />
                  <div style="padding: 14px">
                    <span>{{ item.curriculum_name }}</span>
                    <el-button
                      type="text"
                      class="button"
                      @click="delMyCurriculum(item.id)"
                      style="color: #f56c6c"
                      >删除
                    </el-button>
                    <div class="bottom clearfix">
                      <time class="time">{{ item.createdate }}</time>
                      <el-button
                        @click="intoWork(item.id)"
                        type="text"
                        class="button"
                        >进入</el-button
                      >
                      <el-button
                        type="text"
                        class="button"
                        @click="
                          updateMyCurriculum(item.id, item.curriculum_name)
                        "
                        >修改 <el-divider direction="vertical"></el-divider
                      ></el-button>
                    </div>
                  </div>
                </el-card>
              </div>

              <div class="col-lg-3">
                <el-card :body-style="{ padding: '0px' }">
                  <i
                    class="image el-icon-circle-plus-outline"
                    style="font-size: 180px; color: #8c939d"
                  ></i>
                  <div style="padding: 14px">
                    <div class="bottom clearfix">
                      <el-button
                        type="text"
                        class="button"
                        @click="dialogFormVisible = true"
                        >添加课程</el-button
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
          <div class="shadow myList" ><v-pie :mydata="mydata" w=350 h=380 t="作业统计"></v-pie></div>
        </div>
        <div class="col-lg-12">
          <div class="shadow myList" ><v-pie :mydata="mydata" w=350 h=380 t="课程统计"></v-pie></div>
        </div>
      </div>
    </div>

    <!--打开嵌套表单的 Dialog-->

    <el-dialog title="添加课程" :visible.sync="dialogFormVisible" width="600px">
      <el-form :model="form" label-width="80px" ref="form">
        <el-form-item label="课程名称">
          <el-input v-model="form.curriculum_name"></el-input>
        </el-form-item>

        <el-form-item label="课程图标">
          <el-upload
            name="logoFile"
            class="avatar-uploader"
            :show-file-list="false"
            :limit="1"
            :action="uploadUrl()"
            :on-change="handleChange"
            :before-upload="beforeAvatarUpload"
            :auto-upload="false"
            :data="this.form"
            ref="upload"
          >
            <img v-if="imageUrl" :src="imageUrl" class="avatar" />
            <i v-else class="el-icon-plus avatar-uploader-icon"></i>
          </el-upload>
          <div>只能上传jpg/png文件，且不超过500kb</div>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="dialogFormVisible = false">取 消</el-button>
        <el-button type="primary" @click="insert()">确 定</el-button>
      </div>
    </el-dialog>

    <!--打开修改的 Dialog-->

    <el-dialog
      title="修改课程"
      :visible.sync="dialogFormVisible2"
      width="600px"
    >
      <el-form :model="form" label-width="80px" ref="form">
        <el-form-item label="课程名称">
          <el-input v-model="form.curriculum_name"></el-input>
        </el-form-item>

        <el-form-item label="课程图标">
          <el-upload
            name="logoFile"
            class="avatar-uploader"
            :show-file-list="false"
            :limit="1"
            :action="uploadUrl2()"
            :on-change="handleChange"
            :before-upload="beforeAvatarUpload"
            :auto-upload="false"
            :data="this.form"
            ref="upload"
          >
            <img v-if="imageUrl" :src="imageUrl" class="avatar" />
            <i v-else class="el-icon-plus avatar-uploader-icon"></i>
          </el-upload>
          <div>只能上传jpg/png文件，且不超过500kb</div>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="dialogFormVisible2 = false">取 消</el-button>
        <el-button type="primary" @click="insert()">确 定</el-button>
      </div>
    </el-dialog>
  </div>
</template>
    <style  scoped>
.avatar-uploader {
  border: 1px dashed #d9d9d9;
  border-radius: 6px;
  cursor: pointer;
  position: relative;
  overflow: hidden;
  height: 180px;
  width: 180px;
}
.avatar-uploader:hover {
  border-color: #409eff;
}
.avatar-uploader-icon {
  font-size: 28px;
  color: #8c939d;
  width: 178px;
  height: 178px;
  line-height: 178px;
  text-align: center;
}
.avatar {
  width: 178px;
  height: 178px;
  display: block;
}
.myList {
  background-color: #ffffff;
  border: darkgray;
  border-radius: 0px !important;
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
</style>
<script>
import pie from "@/components/echars/pie";
import curriculumApi from "@/api/curriculum.js";
export default {
  components: {
    "v-pie": pie,
  },
  data() {
    return {
      curriculumList: [],
      dialogFormVisible: false,
      dialogFormVisible2: false,
      imageUrl: "",
      form: {
        id: "",
        curriculum_name: "",
      },
      mydata: [
        { value: 335, name: "直接访问" },
        { value: 310, name: "邮件营销" },
        { value: 234, name: "联盟广告" },
        { value: 135, name: "视频广告" },
        { value: 1548, name: "搜索引擎" },
      ],
    };
  },
  mounted() {
    this.base_api = process.env.VUE_APP_BASE_API;
  },
  created() {
    this.fetchData();
  },
  methods: {
    delMyCurriculum(id) {
      this.$confirm("此操作将永久删除该课程, 是否继续?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
        .then(() => {
          curriculumApi.delCurriculum(id).then((response) => {
            const resp = response.data;
            if (resp.flag) {
              this.$message({
                type: "success",
                message: resp.message,
              });
              this.fetchData();
            } else {
              this.$message.error(resp.message);
            }
          });
        })
        .catch(() => {
          this.$message({
            type: "info",
            message: "已取消删除",
          });
        });
    },
    updateMyCurriculum(id, curriculum_name) {
      this.form.id = id;
      this.form.curriculum_name = curriculum_name;
      this.dialogFormVisible2 = true;
    },
    uploadUrl2() {
      return this.base_api + "/Curriculum/updateCurriculum";
    },
    handleChange(file, fileList) {
      this.imageUrl = URL.createObjectURL(file.raw);
    },
    getImgUrl(filename) {
      return this.base_api + "/CurriculumLogo/" + filename;
    },
    insert(formName) {
          // if(this.fileList.length <= 0){
          //     this.$message.error("请至少上传一个文件！");
          //     return;
          // }
          // if(!this.fileSizeIsSatisfy){
          //     this.$message.error("上传失败！存在文件大小超过5M！");
          //     return;
          // }
          //手动上传文件，在点击确认的时候 校验通过才会去请求上传文件的url
          this.$refs.upload.submit()
          this.$message({
            type: "success",
            message: "操作成功！",
          });
          this.dialogFormVisible = false;
          this.dialogFormVisible2 = false;

       

    },
    uploadUrl: function () {
      return this.base_api + "/Curriculum/AddCurriculum";
    },
    // addcurriculum() {
    //   curriculumApi.addCurriculum(this.form).then((response) => {
    //     const resp = response.data;
    //     if (resp.flag) {
    //       this.$message({
    //         type: "success",
    //         message: resp.message,
    //       });
    //     } else {
    //       this.$message.error(resp.message);
    //     }
    //     this.dialogFormVisible = false;
    //     this.fetchData();
    //   });
    // },
    intoWork(CurriculumId) {
      this.$router.push({ path: "/allWork", query: { id: CurriculumId } });
    },
    beforeAvatarUpload(file) {
      const isJPG = file.type === "image/jpeg";
      const isLt2M = file.size / 1024 / 1024 < 2;

      if (!isJPG) {
        this.$message.error("上传头像图片只能是 JPG 格式!");
      }
      if (!isLt2M) {
        this.$message.error("上传头像图片大小不能超过 2MB!");
      }
      return isJPG && isLt2M;
    },
    fetchData() {
      curriculumApi.getTeacherCurriculumLst().then((response) => {
        const resp = response.data;
        if (resp.flag) {
          this.curriculumList = resp.data;
        }
      });
    },
  },
};
</script>
