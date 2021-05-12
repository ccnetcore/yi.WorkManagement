<template>
  <div id="home">
    <div class="row">
      <div class="col-lg-8" style="padding-right: 0">
        <div class="col-lg-12">
          <div class="shadow myList p-2">
            <el-divider content-position="left">选择题</el-divider>
            <div
              v-for="(item, index) in choice_questionList"
              :key="'info1-' + index"
            >
              <h4>{{ index + 1 }}: {{ item.subject }}</h4>
              <el-radio-group
                v-model="choice_questionList[index].option_select"
              >
                <el-radio :label="'a'" border>{{ item.option_a }}</el-radio>
                <br />
                <el-radio :label="'b'" border>{{ item.option_b }}</el-radio>
                <br />
                <el-radio :label="'c'" border>{{ item.option_c }}</el-radio>
                <br />
                <el-radio :label="'d'" border>{{ item.option_d }}</el-radio>
              </el-radio-group>
            </div>
            <el-divider content-position="left">判断题</el-divider>
            <div
              v-for="(item, index) in judgment_questionList"
              :key="'info2-' + index"
            >
              <h4>{{ index + 1 }}: {{ item.subject }}</h4>
              <el-radio-group
                v-model="judgment_questionList[index].option_select"
              >
                <el-radio :label="'t'" border>正确</el-radio>
                <br />
                <el-radio :label="'f'" border>错误</el-radio>
              </el-radio-group>
            </div>
            <el-divider content-position="left">问答题</el-divider>
            <div
              v-for="(item, index) in fill_questionList"
              :key="'info3-' + index"
            >
              <h4>{{ index + 1 }}: {{ item.subject }}</h4>
              <el-input
                type="textarea"
                :autosize="{ minRows: 2, maxRows: 4 }"
                placeholder="请输入答案"
                v-model="fill_questionList[index].option_input"
              >
              </el-input>
            </div>
          </div>
        </div>
        <div class="col-lg-12">
          <div class="shadow myList p-2">
            <el-button @click="sub" type="primary">提交试卷</el-button>
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
</style>
<script>
import examinationAPI from "@/api/examination";
import workApi from "@/api/work.js";
export default {
  data() {
    return {
      choice_questionList: [],
      judgment_questionList: [],
      fill_questionList: [],
      workData:{},
      studentworkid:""
    };
  },
  created() {
    this.fetchData();
  },
  methods: {
    sub() {//提交试卷
      examinationAPI
        .subExamination1(this.choice_questionList)
        .then((response) => {
          const resp = response.data;
          if (resp.flag) {
            examinationAPI
              .subExamination2(this.judgment_questionList)
              .then((response2) => {
                const resp2 = response2.data;
                if (resp2.flag) {
                  examinationAPI
                    .subExamination3(this.fill_questionList,this.studentworkid)
                    .then((response3) => {
                      const resp3 = response3.data;
                      if (resp3.flag) {
                        this.$router.push({ path: "/index" });
                        this.$notify({
                          title: "考试成功",
                          message: resp3.message,
                          type: "success",
                        });
                      }
                    });
                }
              });
          } else {
            this.$message.error(resp.message);
          }
        });
    },
    fetchData() {
      workApi.getWorkByWorkId(this.$route.query.id).then((response) => {//获得studentworkid
        const resp = response.data;
        if (resp.flag) {
          this.workData = resp.data;
         this.studentworkid=resp.data.id

      examinationAPI
        // .getExaminationListById(this.$route.query.id)
        .getExaminationListById(this.$route.query.id)//得到试卷
        .then((response2) => {
          const resp2 = response2.data;
          if (resp2.flag) {
            this.choice_questionList = resp2.choice;
            this.judgment_questionList = resp2.judgment;
            this.fill_questionList = resp2.fill;
          }
        });


        }
      });



    },
  },
};
</script>
