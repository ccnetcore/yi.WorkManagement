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
          <div class="panel-narrow">
            <div class="title">注册</div>
            <div class="control-group">
              <label>用户名</label>
              <div class="controls">
                <input
                  id="username"
                  type="text"
                  placeholder="4~20 位字母数字下划线"
                  maxlength="20"
                  title="用户名"
                  v-model="form.username"
                />
              </div>
            </div>
            <div class="control-group">
              <label>邮 箱</label>
              <div class="controls">
                <input
                  id="mail"
                  type="text"
                  placeholder="仅支持主流邮箱"
                  title="邮箱"
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
                  placeholder="邮件验证码"
                  maxlength="6"
                  title="验证码"
                  v-model="form.code"
                />
                <button class="mbtn mbtn-code" id="send">获取</button>
              </div>
            </div>
            <div class="control-group">
              <label>密　码</label>
              <div class="controls">
                <input
                  id="password"
                  type="password"
                  placeholder="8~128 位"
                  maxlength="128"
                  title="密码"
                  v-model="form.pwd"
                />
              </div>
            </div>
            <div class="control-group">
              <label style="width: 100%; word-break: break-all">
                * 在 超越系统 注册代表您已阅读并同意 超越 的
                <a href="#">隐私策略</a>、
                <a href="#">服务条款</a>
              </label>
            </div>
            <div class="actions">
              <button class="mbtn mbtn-my" @click="regSub()" id="register">
                注册
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
        username: "",
        pwd: "",
        code: "",
      },
    };
  },
  methods: {
    regSub() {
      accountAPI.register(this.form).then((response) => {
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