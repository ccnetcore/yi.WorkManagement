<template>
  <div>
    <div id="mainHeader">
      <div v-show="$route.path == '/commentInfo'">
        <el-page-header @back="goBack" content="评论"> </el-page-header>
      </div>

      <div v-show="$route.path == '/studentInfo'">
        <el-page-header @back="goBack" content="学生"> </el-page-header>
      </div>
      <div
        v-show="
          $route.path == '/studentCurriculum' ||
          $route.path == '/approvalCurriculum' ||
          $route.path == '/choiceCurriculum' ||
          $route.path == '/teacherCurriculum'
        "
      >
        <el-page-header @back="goBack" content="课程"> </el-page-header>
      </div>
      <div
        v-show="
          $route.path == '/allWork' ||
          $route.path == '/studentWork' ||
          $route.path == '/approvalWork'
        "
      >
        <el-page-header @back="goBack" content="作业"> </el-page-header>
      </div>

      <div v-show="$route.path == '/version'">
        <el-page-header @back="goBack" content="版本"> </el-page-header>
      </div>

      <div v-show="$route.path == '/fileInfo'">
        <el-page-header @back="goBack" content="文件"> </el-page-header>
      </div>

      <div v-show="$route.path == '/examinationInfo'">
        <el-page-header @back="goBack" content="试卷"> </el-page-header>
      </div>
      <div v-show="$route.path == '/install'">
        <el-page-header @back="goBack" content="设置"> </el-page-header>
      </div>
      <div v-show="$route.path == '/studentAccount'">
        <el-page-header @back="goBack" content="账户"> </el-page-header>
      </div>
    
    </div>

    <router-view></router-view>
  </div>
</template>
<style scoped>
#mainHeader {
  background-color: #ffffff;
  width: 100%;
  height: 45px;
  padding-top: 10px;
  padding-bottom: 10px;
  padding-left: 20px;
  padding-right: 20px;
}
</style>
<script>
export default {
  methods: {
    goBack() {
      this.$router.push("/index");
    },
  },
};
</script>