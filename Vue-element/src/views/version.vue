<template>
  <div class="block p-5">
    <el-timeline>
      <el-timeline-item
        v-for="(activity, index) in activities"
        :key="index"
        :color="'#006eff'"
        :timestamp="activity.version_time"
        placement="top"
      >
        <el-card class="text-wrapper">
          <h4>{{ activity.edition }}：</h4>
          <div v-html="activity.version_content">
          
          </div>
          <p>{{ activity.version_author }}：{{ activity.version_time }}</p>
        </el-card>
      </el-timeline-item>
    </el-timeline>
  </div>
</template>
<script>
import versionAPI from "@/api/version";
export default {
  data() {
    return {
      activities: [],
    };
  },
  created() {
    this.fetchData();
  },
  methods: {
    fetchData() {
      versionAPI.getVersionList().then((response) => {
        const resp = response.data;
        if (resp.flag) {
          this.activities = resp.data;
          this.activities.forEach((item) => {
            item.version_content=item.version_content.replace(/\\r\\n/g,"<br/>");
          });
        }
      });
    },
  },
};
</script>
<style scoped>
.text-wrapper {
  white-space: pre-wrap;
}
</style>
