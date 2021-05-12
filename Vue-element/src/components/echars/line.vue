<template>
  <div>
    <div ref="chart" :style="{ width: '800px', height: '400px' }"></div>
  </div>
</template>
<script>
export default {
  props: ["mydata","t"],
  methods: {
    initChart(container, option) {
      var myChart = this.$echarts.init(container);
      myChart.setOption(option);
    },
  },
  mounted() {
    let option = {
      tooltip: {},
      xAxis: {
        type: "category",
        data: ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"],
      },
      yAxis: {
        type: "value",
      },
      color: ["#026295"],
      series: [
        {
          data: this.mydata,
          type: "bar",
        },
      ],
       title: {
        text: this.t, //主标题
        // subtext: "纯属虚构", //副标题
        x: "center", //x轴方向对齐方式
      },
    };
    this.initChart(this.$refs.chart, option);
  },
};
</script>