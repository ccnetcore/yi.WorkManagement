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
        text: '综合素质'
    },
    tooltip: {},
    legend: {
        data: ['预算分配', '实际开销']
    },
    radar: {
        // shape: 'circle',
        name: {
            textStyle: {
                color: '#fff',
                backgroundColor: '#999',
                borderRadius: 3,
                padding: [3, 5]
            }
        },
        indicator: [
            { name: '销售', max: 6500},
            { name: '管理', max: 16000},
            { name: '信息', max: 30000},
            { name: '客服', max: 38000},
            { name: '研发', max: 52000},
            { name: '市场', max: 25000}
        ]
    },
    series: [{
        type: 'radar',
        // areaStyle: {normal: {}},
        data: [
            {
                value: [4300, 10000, 28000, 35000, 50000, 19000],
                name: '预算分配'
            },
            {
                value: [5000, 14000, 28000, 31000, 42000, 21000],
                name: '实际开销'
            }
        ]
    }]
};
    this.initChart(this.$refs.chart, option);
  },
};
</script>