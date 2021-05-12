<template>
  <div class="p-4"  id="china" >
      <v-china></v-china>
  </div>
</template>

<script>
import china from "@/components/echars/china.vue";

export default {
  components: {
    "v-china": china,
  },
};
</script>

<style scoped>
#china{
background-color: #f6f6f6;
height: 100%;
margin-top: -50px;
}
</style>