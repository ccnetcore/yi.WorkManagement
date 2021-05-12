<template>
  <div id="home">
    <div class="row">
      <div class="col-lg-8" style="padding-right: 0">
        <div class="col-lg-12">
          <div class="shadow myList p-2">
            <div class="row">
              <div class="col-lg-3" v-for="(item, i) in workList" :key="i">
                <el-card :body-style="{ padding: '0px' }">
                  <div style="padding: 14px">
                    <span>{{ item.work_name }}</span>
                    <el-button
                    v-if="!myShow"
                      type="text"
                      class="button"
                      @click="delMyWork(item.id)"
                      style="color: #f56c6c"
                      >删除
                    </el-button>
                    <div class="bottom clearfix">
                      <time class="time">{{ item.work_type }}</time>
                      <br />
                      <time class="time">{{ item.time_start }}</time>
                      <br />
                      <time class="time">{{ item.time_end }}</time>

                      <el-button
                        type="text"
                        class="button"
                        @click="intoMyWork(item.id, item.work_type)"
                        >进入</el-button
                      >

                      <el-button
                      v-if="!myShow"
                        type="text"
                        class="button"
                        @click="
                          updateMyWork(
                            item.id,
                            item.work_name,
                            item.work_type,
                            item.time_start,
                            item.time_end
                          )
                        "
                        >修改 <el-divider direction="vertical"></el-divider
                      ></el-button>
                    </div>
                  </div>
                </el-card>
              </div>

              <div class="col-lg-3" v-if="!myShow">
                <el-card :body-style="{ padding: '0px' }">
                  <i
                    class="image el-icon-circle-plus-outline"
                    style="font-size: 50px; color: #8c939d"
                  ></i>
                  <div style="padding: 14px">
                    <div class="bottom clearfix">
                      <el-button
                        type="text"
                        class="button"
                        @click="dialogFormVisible = true"
                        >添加作业</el-button
                      >
                    </div>
                  </div>
                </el-card>
              </div>
            </div>
          </div>
        </div>
        <div class="col-lg-12">
          <div class="shadow myList p-4">
            <h2>
              <span>讨论区</span>
              <el-button
              v-if="!myShow"
                @click="dialogFormVisible2 = true"
                type="primary"
                size="small"
                style="float: right"
                >添加讨论话题</el-button
              >
            </h2>

            <hr />
            <div v-for="(item, i) in discussList" :key="i">
              <h4>
                <strong>{{ item.discuss_title }}</strong>
                <h6 style="color: #606266">
                  发布时间：<em>{{ item.discuss_createdate }}</em>
                </h6>
              </h4>
              <p>{{ item.discuss_content }}</p>
              <router-link
                :to="{ name: 'commentInfo', query: { discussId: item.id } }"
              >
                <p><el-button type="primary" plain>了解详情</el-button></p>
              </router-link>
              <hr />
            </div>
          </div>
        </div>

      </div>
      <div class="col-lg-4">
        <div class="col-lg-12">
          <div class="shadow myList" ><v-pie :mydata="mydata" w=350 h=380 t="作业统计"></v-pie></div>
        </div>
        <div class="col-lg-12">
          <div class="shadow myList" ><v-pie :mydata="mydata" w=350 h=380 t="作业统计"></v-pie></div>
        </div>
      </div>
    </div>
    <!--打开添加作业的 Dialog-->

    <el-dialog title="添加作业" :visible.sync="dialogFormVisible" width="600px">
      <div v-if="!showfilework">
        <el-select v-model="form.work_type" placeholder="请选择作业类型">
          <el-option
            v-for="item in options"
            :key="item.value"
            :label="item.label"
            :value="item.value"
          >
          </el-option>
        </el-select>
        <el-button @click="selectTpye" type="primary" class="mx-2"
          >确定选择</el-button
        >
      </div>
      <div v-if="showfilework">
        <el-form :model="form" status-icon ref="form">
          <el-form-item label="作业名称:" prop="work_name">
            <el-input
              v-model="form.work_name"
              style="width: 60%"
              placeholder="请输入姓名"
              auto-complete="off"
            ></el-input>
          </el-form-item>
        <el-form-item label="作业时间:">
            <el-date-picker
              v-model="value1"
              type="datetimerange"
              :picker-options="pickerOptions"
              range-separator="至"
              start-placeholder="开始日期"
              end-placeholder="结束日期"
              align="right"
            >
            </el-date-picker>
        </el-form-item>

          <el-row type="flex" justify="center">
            <el-col :span="22">
              <el-form-item label="选择作业文件:">
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
        <div slot="footer" class="dialog-footer">
          <el-button type="success" @click="insert('form')">确认发布</el-button>
          <el-button
            @click="
              dialogFormVisible = false;
              showfilework = false;
              form.work_type = '';
            "
            >取 消</el-button
          >
        </div>
      </div>
    </el-dialog>

    <!--打开添加讨论 Dialog-->

    <el-dialog
      title="添加讨论"
      :visible.sync="dialogFormVisible2"
      width="600px"
    >
      <el-form :model="form2" status-icon ref="form">
        <el-form-item label="讨论标题:" prop="discuss_title">
          <el-input
            v-model="form2.discuss_title"
            style="width: 60%"
            placeholder="请输入讨论的标题"
            auto-complete="off"
          ></el-input>
        </el-form-item>
        <el-form-item label="讨论内容:" prop="discuss_content">
          <el-input
            type="textarea"
            v-model="form2.discuss_content"
            style="width: 60%"
            placeholder="请输入需讨论的内容"
            auto-complete="off"
          ></el-input>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="dialogFormVisible2 = false">取 消</el-button>
        <el-button type="success" @click="insert2('form')">确认发布</el-button>
      </div>
    </el-dialog>

    <!--打开修改作业 Dialog-->
    <el-dialog
      title="修改作业"
      :visible.sync="dialogFormVisible3"
      width="600px"
    >
      <el-form :model="form">
        <el-form-item label="作业ID">
          {{ form.id }}
        </el-form-item>
        <el-form-item label="作业类型">
          {{ form.work_type }}
        </el-form-item>
        <el-form-item label="作业名称">
          <el-input v-model="form.work_name" style="width: 60%"></el-input>
        </el-form-item>
        <el-form-item label="作业时间">
          <div class="block">
            <el-date-picker
              v-model="value1"
              type="datetimerange"
              :picker-options="pickerOptions"
              range-separator="至"
              start-placeholder="开始日期"
              end-placeholder="结束日期"
              align="right"
            >
            </el-date-picker>
          </div>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="dialogFormVisible3 = false">取 消</el-button>
        <el-button type="primary" @click="IntoUpdateWork()">确 定</el-button>
      </div>
    </el-dialog>
  </div>
</template>
    <style>
.myList {
  background-color: #ffffff;
  border: darkgray;
  border-radius: 0px !important;
  padding: 20px;
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
import workApi from "@/api/work.js";
import discussApi from "@/api/discuss.js";
// import charsAPI from "@/api/chars";
export default {
    components: {
    "v-pie": pie,
  },
  data() {
    
    return {
      showfilework: false,
      options: [
        {
          value: "1",
          label: "文件",
        },
        {
          value: "2",
          label: "试卷",
        },
        {
          value: "3",
          label: "图片",
        },
      ],
            mydata: [
        { value: 335, name: "直接访问" },
        { value: 310, name: "邮件营销" },
        { value: 234, name: "联盟广告" },
        { value: 135, name: "视频广告" },
        { value: 1548, name: "搜索引擎" },
      ],
      pickerOptions: {
        shortcuts: [
          {
            text: "最近一周",
            onClick(picker) {
              const end = new Date();
              const start = new Date();
              start.setTime(start.getTime() - 3600 * 1000 * 24 * 7);
              picker.$emit("pick", [start, end]);
            },
          },
          {
            text: "最近一个月",
            onClick(picker) {
              const end = new Date();
              const start = new Date();
              start.setTime(start.getTime() - 3600 * 1000 * 24 * 30);
              picker.$emit("pick", [start, end]);
            },
          },
          {
            text: "最近三个月",
            onClick(picker) {
              const end = new Date();
              const start = new Date();
              start.setTime(start.getTime() - 3600 * 1000 * 24 * 90);
              picker.$emit("pick", [start, end]);
            },
          },
        ],
      },
      discussList: [],
      workList: [],
      base_api: "",
      dialogFormVisible: false,
      dialogFormVisible2: false,
      dialogFormVisible3: false,
      form: {
        //作业的表单
        curriculum_id: this.$route.query.id,
        time_start: "2021-01-20T20:37:47.183",
        time_end: "2021-01-20T20:37:47.183",
        work_name: "",
        work_type: "",
      },
      form2: {
        //讨论的表单
        discuss_title: "",
        discuss_content: "",
        curriculum_id: this.$route.query.id,
      },
            myShow: true,
    };
  },
  computed: {
    value1: function () {
      return [this.form.time_start, this.form.time_end];
    },
  },

  mounted() {
    this.base_api = process.env.VUE_APP_BASE_API;
  },

  created() {
    this.getMyShow();
    this.fetchData();

  },
  methods: {
  getMyShow() {
      const myLogin = localStorage.getItem("logged");

      if (myLogin == 0) {
        this.myShow = true;
      }
      if (myLogin == 1) {
        this.myShow = false;
      }
    },
    
    delMyWork(id) {
 this.$confirm('此操作将永久删除该作业, 是否继续?', '提示', {
          confirmButtonText: '确定',
          cancelButtonText: '取消',
          type: 'warning'
        }).then(() => {
    
      workApi.delWorkByWorkId(id).then((response) => {
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
        }).catch(() => {
          this.$message({
            type: 'info',
            message: '已取消删除'
          });          
        });



    },
    IntoUpdateWork() {
      workApi.updateWork(this.form).then((response) => {
        const resp = response.data;
        if (resp.flag) {
          this.$message({
            type: "success",
            message: resp.message,
          });
          this.fetchData();
          this.dialogFormVisible3 = false;

          this.form.work_type = "";
          this.form.work_name = "";
        } else {
          this.$message.error(resp.message);
        }
      });
    },
    updateMyWork(id, work_name, work_type, time_start, time_end) {
      this.form.id = id;
      this.form.work_type = work_type;
      this.form.time_start = time_start;
      this.form.time_end = time_end;
      this.form.work_name = work_name;
      this.dialogFormVisible3 = true;
    },
    selectTpye() {
      if (this.form.work_type == 1) {
        this.showfilework = true;
      }
      if (this.form.work_type == 2) {
        this.$router.push({
          path: "/addExamination",
          query: { curriculumId: this.$route.query.id },
        });
      }
      if (this.form.work_type == 3) {
        this.showfilework = true;
      }
    },
    getImgUrl(filename) {
      return this.base_api + "/CurriculumLogo/" + filename;
    },
    insert2() {
      discussApi.addDiscuss(this.form2).then((response) => {
        const resp = response.data;
        if (resp.flag) {
          this.fetchData();
          this.dialogFormVisible2 = false;
          this.$message({
            type: "success",
            message: resp.message,
          });
        } else {
          this.$message.error(resp.message);
        }
      });
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
      this.$refs.upload.submit();
      this.dialogFormVisible=false;
      this.$message({
        type: "success",
        message: "作业添加成功！所有课程下的学生已发布作业！",
      });
    },
    uploadUrl: function () {
      return this.base_api + "/work/AddWork";
    },
    intoMyWork(workId, type) {
      if (type == 1) {
        this.$router.push({ path: "/fileInfo", query: { id: workId } });
      }
      if (type == 2) {
        this.$router.push({ path: "/examinationInfo", query: { id: workId } });
      }
      if (type == 3) {
        this.$router.push({ path: "/imageInfo", query: { id: workId } });
      }
    },
    fetchData() {
      workApi
        .getWorklistByCurriculumId(this.$route.query.id)
        .then((response) => {
          const resp = response.data;
          if (resp.flag) {
            this.workList = resp.data;
          }
          discussApi
            .getDiscussListByCurriculumId(this.$route.query.id)
            .then((response2) => {
              const resp2 = response2.data;
              if (resp2.flag) {
                this.discussList = resp2.data;
                
      // charsAPI.getWorkGroup().then((response3) => {
      //   const resp3 = response3.data;
      //   this.mydata.data = resp3;
      // });

              }
            });
        });
    },
  },
};
</script>
