<template>
  <div>
    <el-menu
      :default-active="activeIndex2"
      class="el-menu-demo"
      mode="horizontal"
      @select="handleSelect"
      :background-color=theme
      :text-color=themeColor
      active-text-color="#ffffff"
    >
      <el-menu-item index="1" style="width: 200px">
        <i class="el-icon-box" style="font-size: 30px; margin-right: 30px"></i
        ><span style="font-size: 15px">作业管理系统</span></el-menu-item
      >
     <el-menu-item index="2"
        >总览</el-menu-item
      >
      <el-submenu index="3">
        <template slot="title">系列</template>
        <el-menu-item index="3-1">选项1</el-menu-item>
        <el-menu-item index="3-2">选项2</el-menu-item>
        <el-menu-item index="3-3">选项3</el-menu-item>
        <el-submenu index="3-4">
          <template slot="title">选项4</template>
          <el-menu-item index="3-4-1">选项1</el-menu-item>
          <el-menu-item index="3-4-2">选项2</el-menu-item>
          <el-menu-item index="3-4-3">选项3</el-menu-item>
        </el-submenu>
      </el-submenu>
   
      <el-menu-item index="4"
        >学生</el-menu-item
      >
      <el-menu-item index="5"
        >教师</el-menu-item
      >

      <el-submenu index="6" style="float: right">
        <template slot="title"><el-avatar style="margin-right: 10px" :size="30"> {{myname}} </el-avatar>{{myusername}}</template>
        <el-menu-item index="6-1" @click.native="$router.push('/studentAccount');">查看账户</el-menu-item>
        <el-menu-item index="6-2 "  @click.native="$router.push('/studentAccount');">修改密码</el-menu-item>
      <el-menu-item index="6-3" @click.native="logout()">安全退出</el-menu-item>
      </el-submenu>

      <el-submenu index="7" style="float: right">
        <template slot="title">消息</template>
        <el-menu-item index="7-1">查看消息</el-menu-item>
        <el-menu-item index="7-2">历史消息</el-menu-item>
      </el-submenu>



      <el-menu-item index="8" style="float: right"
        >支持</el-menu-item
      >
      <el-menu-item index="9" style="float: right"
        ><i class="el-icon-help"></i>
      </el-menu-item>
      <el-menu-item index="10" style="float: right"
        ><i class="el-icon-refresh"></i></el-menu-item>
    </el-menu>
  </div>
</template>
<script>
import account from "@/api/account";
  import {headerBg,navbarColor} from '../../public/js/theme.js'
export default {
  data() {
    return {
      activeIndex: "1",
      activeIndex2: "1",
      theme:"",
      themeColor:"",
      myname:"",
      myusername:""
    };
  },
  mounted() {
       const style = localStorage.getItem("theme");
  this.theme=headerBg(style)
  this.themeColor= navbarColor(style)
  this.myname = localStorage.getItem("name");
  this.myusername=localStorage.getItem("username")
},
  methods: {
    handleSelect(key, keyPath) {
      console.log(key, keyPath);
    },
    logout() {
      account.logOff().then((response) => {
        const resp = response.data;
        if (resp.flag) {
          localStorage.clear();
          this.$notify({
            title: "成功",
            message: resp.message,
            type: "success",
          });
          this.$router.push("/login");
          
        } else {
          this.$notify.error({
            title: "错误",
            message: "退出失败",
          });
        }
      });
    },
  },
};
</script>
<style scoped>
.el-menu {
  border-bottom: none !important;
  height: 100%;
  width: 100%;
}
.el-menu-item  {
    border-bottom: none !important;
text-align: center;
}
</style>