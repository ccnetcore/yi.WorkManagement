<template>
  <div id="app2" class="login">
    <div class="single-bg"></div>
    <div class="notify-container"></div>
    <div class="main2 padding-limiter">
      <div class="panel login-panel">
        <div class="double-column">
          <img
            class="panel-wide login-img"
            src="../../public/images/baner.jpg"
          />
          <div class="panel-narrow" id="p-login">
            <div class="title">找回密码</div>
            <div class="control-group">
              <label>邮　箱</label>
              <div class="controls">
                <input
                  id="target"
                  type="text"
                  placeholder="输入账户邮箱"
                  v-model="form.mail"
                />
              </div>
            </div>
            <div class="control-group">
              <label>验证码</label>
              <div class="controls">
                <input
                  id="code"
                  type="text"
                  placeholder="邮件/短信验证码"
                  maxlength="6"
                  v-model="form.code"
                />
                <button class="mbtn mbtn-code" id="send">获取</button>
              </div>
            </div>
            <div class="control-group">
              <label>新密码</label>
              <div class="controls">
                <input
                  id="password"
                  type="password"
                  placeholder="8~128 位"
                  maxlength="128"
                  v-model="form.pwd"
                />
              </div>
            </div>
            <div class="actions">
              <button class="mbtn mbtn-my" @click="subReset" id="submit">
                提交
              </button>
              <router-link :to="{ name: 'login' }">
                <button class="mbtn" id="back">返回</button></router-link
              >
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import accountAPI from "@/api/account";
export default {
  data() {
    return {
      form: {
        mail: "",
        pwd: "",
        code: "",
      },
    };
  },
  methods: {
    subReset() {
      accountAPI.resetPwd(this.form).then((response) => {
        const resp = response.data;
        if (resp.flag) {
          this.$notify({
            title: "成功",
            message: resp.message,
            type: "success",
          });
          this.$router.push("/login");
        } else {
          this.$notify.error({
            title: "错误",
            message: resp.message,
          });
        }
      });
    },
  },
};
</script>