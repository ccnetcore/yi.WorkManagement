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
            <div class="title">作业管理系统 登录</div>
            <div class="control-group">
              <label>账　户</label>
              <div class="controls">
                <input
                  v-model="ruleForm.username"
                  id="username"
                  type="text"
                  placeholder="用户名/邮箱/手机号"
                  title="账户"
                />
              </div>
            </div>
            <div class="control-group">
              <label>密　码</label>
              <div class="controls">
                <input
                  v-model="ruleForm.pwd"
                  id="password"
                  type="password"
                  title="密码"
                  placeholder="密码"
                />
              </div>
            </div>
            <div class="control-group">
              <label>验证码</label>
              <div class="controls">
                <div id="slider">
                  <div id="slider_bg"></div>
                  <span id="label">>></span>
                  <span id="labelTip">拖动滑块验证</span>
                </div>

                <div
                  id="huadongImage"
                  style="
                    width: 300px;
                    border: 1px solid #ccc;
                    height: 250px;
                    z-index: 200;
                    display: none;
                    position: absolute;
                    background-color: white;
                    top: 130px;
                  "
                ></div>
              </div>
            </div>
            <div style="text-align: right">
              <label>
                <router-link :to="{ name: 'register' }">
                  <a href="#">注册</a></router-link
                >
                <router-link :to="{ name: 'reset_password' }">
                  <a href="#" style="margin: 0 60px 0 8px" class="wtf-fix"
                    >忘记密码?</a
                  ></router-link
                >
              </label>
            </div>
            <div class="actions">
              <button @click="submitForm" class="mbtn mbtn-my" id="login">
                登录
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import account from "@/api/account";
import { mycode } from "../../public/js/code";

export default {
  created() {
    this.codeData();
  },
  data() {
    return {
      ruleForm: {
        username: "",
        pwd: "",
      },
      showCode: false,
    };
  },
  methods: {
    codeData() {
      mycode();
      $(document).ready(function () {
        Slider_init();
      });
      function Slider_init() {
        var slider = new SliderUnlock(
          "#slider",
          {
            successLabelTip: "验证成功",
          },
          function () {
            huadongCode();
          }
        );
        slider.init();
      }

      function huadongCode() {
        num = 1;
        checkCode = [];

        account.VerificationCodeImage().then((response) => {
          const data = response.data;
          var html =
            "<div id=\"imagediv\" style='position: absolute;left:10px; top:30px;background: #fff;z-index:300'><img src=" +
            data.result +
            ' alt="看不清？点击更换" id="image"/></div>';
          html +=
            "<div id='divrefresh' style='width:20px;height:20px;position:absolute;cursor: pointer;margin-left: 90%;'> <img src=\"/images/resCode.jpg\" /> </div>";
          $("#huadongImage").css("display", "block").html(html);
          $("#labelTip").html(data.msg);
          imageClick();
          divrefreshClick();
        });
      }

      function divrefreshClick() {
        $("#divrefresh").click(function () {
          huadongCode();
          num = 1;
          checkCode = [];
        });
      }

      var num = 1;
      var checkCode = [];
      function createPoint(pos) {
        if (num == 2) {
          PostcheckCode();
        }

        $("#imagediv").append(
          '<div class="point-area" onclick="pointClick(this)" style="background-color:#539ffe;color:#fff;z-index:9999;width:25px;height:25px;text-align:center;line-height:25px;border-radius: 20%;position:absolute;border:2px solid white;top:' +
            parseInt(pos.y - 10) +
            "px;left:" +
            parseInt(pos.x - 10) +
            'px;">' +
            num +
            "</div>"
        );
        ++num;
      }

      function PostcheckCode() {
        account.PostcheckCode(checkCode).then((response) => {
          const d = response.data;
          if (d.status == "ok") {
            $("#labelTip").html(d.msg);
            $("#huadongImage").hide();
            localStorage.setItem("token", d.token);
          } else {
            huadongCode();
          }
        });
      }

      function pointClick(obj) {
        num = 1;
        checkCode = [];
        $(obj).parent().find(".point-area").remove();
      }

      function getMousePos(obj, event) {
        var e = event || window.event;
        var x = e.clientX - ($(obj).offset().left - $(window).scrollLeft());
        var y = e.clientY - ($(obj).offset().top - $(window).scrollTop());
        checkCode.push({ _X: parseInt(x), _Y: parseInt(y) });
        return { x: parseInt(x), y: parseInt(y) };
      }

      function imageClick() {
        $("#imagediv").click(function () {
          var _this = $(this);
          var pos = getMousePos(_this);
          createPoint(pos);
        });
      }
    },
    submitForm() {
      account.login(this.ruleForm).then((response) => {
        const resp = response.data;
        if (resp.flag) {
          localStorage.setItem("logged", resp.data);
           localStorage.setItem("name",resp.message.substr(6))
localStorage.setItem("username",resp.message2)
          this.$notify({
            title: "成功",
            message: resp.message,
            type: "success",
          });
          this.$router.push("/");
        } else {
          this.$notify.error({
            title: "错误",
            message: resp.message,
          });
        }
      });
    },
    resetForm(formName) {
      this.$refs[formName].resetFields();
    },
    mounted() {
      this.base_api = process.env.VUE_APP_BASE_API;
    },
  },
};
</script>
<style scoped>
@import "../../public/css/base.min.css";
@import "../../public/css/slide-unlock.css";
</style>