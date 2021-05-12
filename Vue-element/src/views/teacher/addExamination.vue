<template>
  <div id="home">
    <div class="row">
      <div class="col-lg-8" style="padding-right: 0">
        <div class="col-lg-12">
          <div class="shadow myList p-2">
            <div>
              <el-form :model="form" status-icon ref="form">
                <el-form-item label="作业名称:" prop="work_name">
                  <el-input
                    v-model="form.work_name"
                    style="width: 60%"
                    placeholder="请输入作业名"
                    auto-complete="off"
                  ></el-input>
                </el-form-item>
                <div class="block">
                  <span class="demonstration">作业有效期:</span>
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
              </el-form>
            </div>

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

            <div>
              <h4>
                <el-input
                  placeholder="请输入题目"
                  :autosize="{ minRows: 2, maxRows: 4 }"
                  v-model="choice_question.subject"
                >
                  <template slot="prepend">题目:</template>
                </el-input>
              </h4>

              <el-input
                placeholder="请输入选项A"
                :autosize="{ minRows: 2, maxRows: 4 }"
                v-model="choice_question.option_a"
              >
                <template slot="prepend">选项A</template>
              </el-input>
              <br />
              <el-input
                placeholder="请输入选项B"
                :autosize="{ minRows: 2, maxRows: 4 }"
                v-model="choice_question.option_b"
              >
                <template slot="prepend">选项B</template>
              </el-input>
              <br />
              <el-input
                placeholder="请输入选项C"
                :autosize="{ minRows: 2, maxRows: 4 }"
                v-model="choice_question.option_c"
              >
                <template slot="prepend">选项C</template>
              </el-input>
              <br />
              <el-input
                placeholder="请输入选项D"
                :autosize="{ minRows: 2, maxRows: 4 }"
                v-model="choice_question.option_d"
              >
                <template slot="prepend">选项D</template>
              </el-input>
              <div class="p-4">
                <span>正确选项：</span>
                <el-radio-group v-model="choice_question.option_correct">
                  <el-radio :label="'a'">选项A</el-radio>
                  <el-radio :label="'b'">选项B</el-radio>
                  <el-radio :label="'c'">选项C</el-radio>
                  <el-radio :label="'d'">选项D</el-radio>
                </el-radio-group>
              </div>
            </div>

            <el-button class="my-2" type="primary" @click="add1"
              >添加选择题</el-button
            >

            <el-divider content-position="left">判断题</el-divider>
            <div
              v-for="(item, index) in judgment_questionList"
              :key="'info2-' + index"
            >
              <h4>{{ index + 1 }}: {{ item.subject }}</h4>
            </div>

            <div>
              <h4>
                <el-input
                  placeholder="请输入题目"
                  :autosize="{ minRows: 2, maxRows: 4 }"
                  v-model="judgment_question.subject"
                >
                  <template slot="prepend">题目:</template>
                </el-input>
              </h4>

              <div class="p-4">
                <span>答案选项：</span>
                <el-radio-group v-model="judgment_question.option_correct">
                  <el-radio :label="'t'">正确</el-radio>
                  <el-radio :label="'f'">错误</el-radio>
                </el-radio-group>
              </div>
            </div>

            <el-button class="my-2" type="primary" @click="add2"
              >添加判断题</el-button
            >

            <el-divider content-position="left">问答题</el-divider>
            <div
              v-for="(item, index) in fill_questionList"
              :key="'info3-' + index"
            >
              <h4>{{ index + 1 }}: {{ item.subject }}</h4>
            </div>
            <div>
              <h4>
                <el-input
                  placeholder="请输入题目"
                  :autosize="{ minRows: 2, maxRows: 4 }"
                  v-model="fill_question.subject"
                >
                  <template slot="prepend">题目:</template>
                </el-input>
              </h4>

              <el-input
                placeholder="请输入答案"
                :autosize="{ minRows: 2, maxRows: 4 }"
                v-model="fill_question.option_correct"
              >
                <template slot="prepend">答案:</template>
              </el-input>
            </div>

            <el-button class="my-2" type="primary" @click="add3"
              >添加问答题</el-button
            >
          </div>
        </div>

        <div class="col-lg-12">
          <div class="shadow myList p-2">
            <el-button @click="sub" type="success">添加试卷</el-button>
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
      form: {
        //作业的表单
        curriculum_id: this.$route.query.curriculumId,
        time_start: "2021-01-20T20:37:47.183",
        time_end: "2021-01-20T20:37:47.183",
        work_name: "",
        work_type: "2",
      },
      choice_questionList: [],
      judgment_questionList: [],
      fill_questionList: [],
      workData: {},
      studentworkid: "",
      choice_question: {
        subject: "",
        option_a: "",
        option_b: "",
        option_c: "",
        option_d: "",
        option_correct: "",
        work_id: "",
      },
      judgment_question: {
        subject: "",
        option_correct: "",
        work_id: "",
      },
      fill_question: {
        subject: "",
        option_correct: "",
        work_id: "",
      },
    };
  },
  computed: {
    value1: function () {
      return [this.form.time_start, this.form.time_end];
    },
  },
  created() {
    this.fetchData();
  },
  methods: {
    add1() {
      var objct = JSON.parse(JSON.stringify(this.choice_question));
      this.choice_questionList.push(objct);
      this.choice_question.subject = "";
      this.choice_question.option_a = "";
      this.choice_question.option_b = "";
      this.choice_question.option_c = "";
      this.choice_question.option_d = "";
      this.choice_question.option_correct = "";
    },
    add2() {
      var objct2 = JSON.parse(JSON.stringify(this.judgment_question));
      this.judgment_questionList.push(objct2);
      this.judgment_question.subject = "";
      this.judgment_question.option_correct = "";
    },
    add3() {
      var objct3 = JSON.parse(JSON.stringify(this.fill_question));
      this.fill_questionList.push(objct3);
      this.fill_question.subject = "";
      this.fill_question.option_correct = "";
    },
    sub() {
      //提交试卷
      workApi.addWorkByAjax(this.form).then((response1) => {
        const resp1 = response1.data;
        const myworkId = resp1.data;
        this.choice_questionList.forEach(function (item) {
          item.work_id = myworkId;
        });
        this.judgment_questionList.forEach(function (item) {
          item.work_id = myworkId;
        });
        this.fill_questionList.forEach(function (item) {
          item.work_id = myworkId;
        });
        examinationAPI
          .addExamination1(this.choice_questionList)
          .then((response) => {
            const resp = response.data;
            if (resp.flag) {
              examinationAPI
                .addExamination2(this.judgment_questionList)
                .then((response2) => {
                  const resp2 = response2.data;
                  if (resp2.flag) {
                    examinationAPI
                      .addExamination3(
                        this.fill_questionList,
                        this.studentworkid
                      )
                      .then((response3) => {
                        const resp3 = response3.data;
                        if (resp3.flag) {
                          this.$router.push({ path: "/index" });
                          this.$notify({
                            title: "添加试卷作业成功",
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
      });
    },
    fetchData() {},
  },
};
</script>
