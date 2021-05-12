<template>
  <div>
    <v-pie :mydata="mydata" w="350" h="380" t="作业统计"></v-pie>
  </div>
</template>
<script>
import pie from "@/components/echars/pie";
import charsAPI from "@/api/chars";
export default {
  components: {
    "v-pie": pie,
  },
  data() {
    return {
      mydata: [],
    };
  },
  created() {
    this.fetchData();
  },
  methods: {
    fetchData() {
      charsAPI.getWorkGroup().then((response) => {
        const resp = response.data;
        this.mydata = resp;
      });
    },
  },
};
</script>