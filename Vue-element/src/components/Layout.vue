<template>
  <div>
    <el-container>
      <el-header><app-header></app-header></el-header>
      <el-container>
        <el-aside :style="{ backgroundColor: theme }"
          ><app-navbar></app-navbar
        ></el-aside>
        <el-main> <app-main></app-main> </el-main>
      </el-container>
    </el-container>
    <!-- <app-header class="header"></app-header>
       <app-navbar class="navbar"></app-navbar>
       <app-main class="main"></app-main> -->
  </div>
</template>
<script>
import { navbarBg } from "../../public/js/theme.js";
import AppHeader from "./AppHeader.vue";
import AppNavbar from "./AppNavbar.vue";
import AppMain from "./AppMain.vue";
export default {
  mounted() {
    const style = localStorage.getItem("theme");
    this.theme = navbarBg(style);
  },
  data() {
    return {
      theme: "",
    };
  },
  components: {
    AppHeader,
    AppNavbar,
    AppMain,
  },
};
</script>
<style scoped>
.header {
  position: absolute;
  height: 60px;
  top: 0px;
  left: 0px;
  right: 0px;
  background-color: #262f3e;
  padding: 0px;
}
.navbar {
  position: absolute;
  width: 200px;
  left: 0px;
  top: 60px;
  bottom: 0px;
  background-color: #ffffff;
  overflow-y: auto;
  padding: 0px;
}
.main {
  background-color: #f3f4f7;
  position: absolute;
  left: 200px;
  right: 0px;
  bottom: 0px;
  top: 60px;
  padding: 0px;
  overflow-y: auto;
}
.el-header {
  background-color: #1e222d;
  color: #333;
  text-align: center;
  padding: 0;
}

.el-aside {
  color: #333;
  width: auto !important;
  padding: 0;
}

.el-main {
  background-color: #e9eef3;
  color: #333;

  padding: 0;
}

body > .el-container {
  margin-bottom: 40px;
}

</style>