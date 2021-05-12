<template>
  <div style="overflow-x: hidden">
    <div class="container-xl my-xl-2 con p-0">
      <div class="row justify-content-center">
        <div class="py-3 col-12 shadow-sm text-left bg-white">
          <el-divider content-position="left">主题设置</el-divider>

          <div>
            <h4>
              <h2>
                <strong>默认</strong>
              </h2>
              <p>作者:FYZY</p>
              <h6 style="color: #606266">发布时间：<em>2021</em></h6>
            </h4>
            <p>腾讯云风格，让你遨游在软件之海中。</p>
            <p>
              <el-button type="primary" @click="theme(1)" plain>应用</el-button>
            </p>
            <hr />
          </div>

          <div>
            <h4>
              <h2>
                <strong>蔚蓝天空</strong>
              </h2>
              <p>作者:FYZY</p>
              <h6 style="color: #606266">发布时间：<em>2021</em></h6>
            </h4>
            <p>仿佛无边无际的世界。</p>
            <p>
              <el-button type="primary" @click="theme(2)" plain>应用</el-button>
            </p>
            <hr />
          </div>

          <div>
            <h4>
              <h2>
                <strong>橙子世界</strong>
              </h2>
              <p>作者:FYZY</p>
              <h6 style="color: #606266">发布时间：<em>2021</em></h6>
            </h4>
            <p>活泼，热情，激昂澎湃。</p>
            <p>
              <el-button type="primary" @click="theme(3)" plain>应用</el-button>
            </p>
            <hr />
          </div>
        </div>

        <div class="py-3 my-3 col-12 shadow-sm text-left bg-white">
        
          <el-divider content-position="left">其他设置</el-divider>
          <div>
            <h4>
              <h2>
                <strong>暂无</strong>
              </h2>
              <p>作者:暂无</p>
              <h6 style="color: #606266">发布时间：<em>暂无</em></h6>
            </h4>
            <p>暂无。</p>
            <p><el-button type="primary" plain>不可用</el-button></p>
            <hr />
          </div>
        </div>


      </div>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {};
  },

  methods: {
    theme(num) {
      localStorage.setItem("theme", num);
      this.$router.go(0);
    },
  },
  created() {},
};
</script>
<style scoped>
.input {
  width: 700px;
}
.sendComment {
  float: right;
}
</style>