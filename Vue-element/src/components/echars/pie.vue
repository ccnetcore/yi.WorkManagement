<template>
  <div>
    <div ref="chart" :style="{ width: w+'px', height: h+'px' }"></div>
  </div>
</template>
<script>
export default {
  props: ["mydata","w","h","t"],
  methods: {
    initChart(container, option) {
      var myChart = this.$echarts.init(container);
      myChart.setOption(option);
    },
  },
  mounted() {
    let option = {
      title: {
        text: this.t, //主标题
        // subtext: "纯属虚构", //副标题
        x: "center", //x轴方向对齐方式
      },
      tooltip: {
        trigger: "item",
        formatter: "{a} <br/>{b} : {c} ({d}%)",
      },

      series: [
        {
          type: "pie",
          radius: "60%",
          data: this.mydata,
          itemStyle: {
            emphasis: {
              shadowBlur: 10,
              shadowOffsetX: 0,
              shadowColor: "rgba(0, 0, 0, 0.5)",
            },
          },
        },
      ],
    };
    this.initChart(this.$refs.chart, option);
  },
};
</script>