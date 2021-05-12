const webpack = require('webpack')

module.exports = {
  configureWebpack: {
    plugins: [
      // 支持 jquery
      new webpack.ProvidePlugin({
        $: "jquery",
        jQuery: "jquery",
        "windows.jQuery": "jquery"
      })
    ],
  },
  devServer: {
    port: 6789,
    open: true,
    https: false,
    host: "localhost",
    proxy: {
      [process.env.VUE_APP_BASE_API]: {
        target: process.env.VUE_APP_SERVICE_URL,
        changeOrigin: true,
        pathRewrite: {
          ['^' + process.env.VUE_APP_BASE_API]: ''
        }
      }
    }
  },
  lintOnSave:false, //关闭格式检查
  productionSourceMap:false
}