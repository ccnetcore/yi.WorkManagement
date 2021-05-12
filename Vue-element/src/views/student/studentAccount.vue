<template>
  <div style="overflow-x: hidden">
    <div class="container-xl my-xl-2 con p-0">
      <div class="row justify-content-center">
        <div class="py-3 col-12 shadow-sm text-left bg-white">
          <div>
            <h2>
              <strong>我的信息</strong>
            </h2>
            <hr />

            <el-form
              ref="myform"
              :rules="rules"
              :model="form"
              label-width="80px"
            >
              <el-form-item label="学生ID">
                <el-input-number
                  v-model="form.id"
                  :disabled="true"
             
                ></el-input-number>
              </el-form-item>

              <el-form-item label="学号" >
                <el-input-number
                  v-model="form.student_number"
                  :style="{ width: '300px' }"
                ></el-input-number>
              </el-form-item>

              <el-form-item label="姓名" prop="student_name">
                <el-input
                  v-model="form.student_name"
                  size="mini"
                  :style="{ width: text(form.student_name) }"

                ></el-input>
              </el-form-item>

              <el-form-item label="班级" prop="student_class">
                <el-input
                  v-model="form.student_class"
                  size="mini"
                  :style="{ width: text(form.student_class) }"
                ></el-input>
              </el-form-item>
              <el-form-item label="年龄">
                <el-input-number
                  v-model="form.student_age"
                  :min="1"
                  :max="200"
                ></el-input-number>
              </el-form-item>
              <el-form-item label="邮箱">
                <el-input
                  v-model="form.student_mailbox"
                  size="mini"
                  :style="{ width: text(form.student_mailbox) }"
                  :disabled="true"
                ></el-input>
              </el-form-item>

              <el-form-item label="电话" prop="student_phone">
                <el-input
                  v-model="form.student_phone"
                  size="mini"
                  :style="{ width: text(form.student_phone) }"
                ></el-input>
              </el-form-item>

              <el-form-item label="用户名" >
                <el-input
                  v-model="form.student_username"
                  size="mini"
                  :style="{ width: text(form.student_username) }"
                  :disabled=true
                ></el-input>
              </el-form-item>

              <el-form-item label="密码" prop="student_password">
                <el-input
                  v-model="form.student_password"
                  size="mini"
                  :style="{ width: text(form.student_password) }"
                ></el-input>
              </el-form-item>
              <el-form-item>
                <el-button type="primary" @click="updateData()">修改</el-button>
              </el-form-item>
            </el-form>

            <hr />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import studentAPI from "@/api/student";
export default {
  data() {
    return {
      rules: {
        student_class: [
          { required: true, message: "请输入班级名称", trigger: "blur" },
        ],
        student_username: [
          { required: true, message: "请输入用户名", trigger: "blur" },
          {
            min: 3,
            max: 12,
            message: "长度在 3 到 12 个字符",
            trigger: "blur",
          },
        ],
        student_password: [
          { required: true, message: "请输入密码", trigger: "blur" },
          {
            min: 3,
            max: 128,
            message: "长度在 3 到 128 个字符",
            trigger: "blur",
          },
        ],
        student_phone: [
          { required: true, message: "请输入号码", trigger: "blur" },
          { min: 11, max: 11, message: "长度11个字符", trigger: "change" },
        ],
                student_name: [
          { required: true, message: "请输入姓名", trigger: "blur" },
          {  max: 6, message: "长度小于6个字符", trigger: "blur" },
        ],
      },

      form: {
        id: "",
        student_number: "",
        student_name: "",
        student_class: "",
        student_age: "",
        student_mailbox: "",
        student_phone: "",
        student_username: "",
        student_password: "",
      },
    };
  },
  created() {
    this.fetchData();
  },
  methods: {
    updateData() {
      this.$refs["myform"].validate((valid) => {
        if (valid) {
          var newData = JSON.parse(JSON.stringify(this.form));

          newData.student_number = this.form.student_number + "";
          studentAPI.updateStudent(newData).then((response) => {
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
        } else {
          this.$message.error("请输入合理的数据");
        }
      });
    },
    fetchData() {
      studentAPI.getStudent().then((response) => {
        const resp = response.data;
        this.form = resp.data;
      });
    },
  },
  computed: {
    text() {
      return function (value) {
        if (String(value).length <= 20) {
          return "30%";
        } else {
          return String(value).length * 1.2 + "rem";
        }
      };
    },
  },
};
</script>

<style scoped>
  [class*=" el-icon-"], [class^="el-icon-"] {

    line-height: 2.9 !important;

}
</style>