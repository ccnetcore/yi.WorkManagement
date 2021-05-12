<template>
  <div>

    <el-menu
      :router="true"
      default-active="/index"
      class="el-menu-vertical-demo"
       :collapse="isCollapse"
      @open="handleOpen"
      @close="handleClose"
      :text-color=themeColor
      active-text-color="#FFFFFF"
      :background-color=theme
      unique-opened="true"
      
    >

      <el-menu-item index="/index">
        <i class="el-icon-menu"></i>
        <span slot="title">首页</span>
      </el-menu-item>

      <el-menu-item v-if="myShow" index="/studentInfo">
        <i class="el-icon-user-solid"></i>
        <span slot="title">个人主页</span>
      </el-menu-item>

      <el-submenu index="2">
        <template slot="title">
          <i class="el-icon-s-platform"></i>
          <span>课程管理</span>
        </template>
        <el-menu-item-group>
          <el-menu-item v-if="myShow" index="/studentCurriculum"
            >我的课程</el-menu-item
          >
          <el-menu-item v-if="myShow" index="/choiceCurriculum"
            >选择课程</el-menu-item
          >
          <el-menu-item v-if="!myShow" index="/teacherCurriculum"
            >教师课程</el-menu-item
          >
          <el-menu-item v-if="!myShow" index="/approvalCurriculum"
            >审批课程</el-menu-item
          >
        </el-menu-item-group>
      </el-submenu>

      <el-submenu index="3">
        <template slot="title">
          <i class="el-icon-star-on"></i>
          <span>作业管理</span>
        </template>
        <el-menu-item-group>
          <el-menu-item v-if="myShow" index="/studentWork"
            >我的作业</el-menu-item
          >
          <el-menu-item v-if="!myShow" index="/approvalWork"
            >批改作业</el-menu-item
          >
        </el-menu-item-group>
      </el-submenu>

      <el-menu-item index="/install">
        <i class="el-icon-s-tools"></i>
        <span slot="title">系统设置</span>
      </el-menu-item>
      <el-menu-item index="/version">
        <i class="el-icon-s-order"></i>
        <span slot="title">更新版本</span>
      </el-menu-item>
                <el-menu-item v-show="showNav" @click="isCollapse=false;showNav=false;" >
        <i class="el-icon-s-unfold"></i>
        <span slot="title">展开菜单</span>
      </el-menu-item>

                  <el-menu-item v-show="!showNav"  @click="isCollapse=true;showNav=true;" >
        <i class="el-icon-s-fold"></i>
        <span slot="title">收缩菜单</span>
      </el-menu-item>


    </el-menu>
  </div>
</template>


<script>
import { navbarBg,navbarColor } from "../../public/js/theme.js";

export default {
  data() {
    return {
      isCollapse: false,
      theme: "",
      themeColor:"",
      showNav:false
    };
  },
  mounted() {
    const style = localStorage.getItem("theme");
      this.theme = navbarBg(style);
this.themeColor=navbarColor(style)
  },
  created() {
    this.getMyShow();
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
    handleOpen(key, keyPath) {
      console.log(key, keyPath);
    },
    handleClose(key, keyPath) {
      console.log(key, keyPath);
    },
  },
};
</script>
<style scoped>
.el-menu {
  border-right: none;
}

.el-menu-item.is-active {
  background-color: #006eff !important;
}
  .el-menu-vertical-demo:not(.el-menu--collapse) {
    width: 200px;
    min-height: 660px;
  }
  [class*=" el-icon-"], [class^="el-icon-"] {

    line-height: 2.9 !important;

}
</style>