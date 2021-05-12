<template>
  <div style="overflow-x: hidden;">
    <div class="bg-white my-2 py-2  shadow-sm row " >
      <div id="myHeader" class="col-xl-8 bg-blue mx-auto">
        <h4>
          <strong>{{ discussData.discuss_title }}</strong>
          <h6 style="color: #606266">
            课程:<em>{{ discussData.curriculum_id }}</em> 发布时间：<em>{{
              discussData.discuss_createdate
            }}</em>
            发布作者:<em>{{ discussData.discuss_author }}</em>
          </h6>
        </h4>
        <p>{{ discussData.discuss_content }}</p>
        <el-input
          type="textarea"

          placeholder="请输入内容"
          v-model="form.comment_content"
          class="my-4 input"
        >
        </el-input>
        <el-button
          class="sendComment my-4"
          type="primary"
          plain
          @click="addComment()"
          >发表评论</el-button
        >
      </div>
    </div>
    <div class="container-xl my-xl-2 con p-0">
      <div class="row justify-content-center">
        <div class="col-lg-9 col-12 my-xl-2">
          <div class="py-3 col-12 shadow-sm text-left bg-white">
            <div v-show="!exit">
              <h4><strong>暂无评论！赶紧来抢沙发吧!!!</strong></h4>
            </div>
            <div v-show="exit">
              <div v-for="(item, i) in commentList" :key="i">
                <h4>
                  <h2><strong>{{ i + 1 }}楼：</strong></h2>
                  <p>作者:{{ item.comment_author }}</p>
                  <h6 style="color: #606266">
                    发布时间：<em>{{ item.comment_createdate }}</em>
                  </h6>
                </h4>
                <p>{{ item.comment_content }}</p>
                <p><el-button type="primary" plain>点赞</el-button></p>
                <hr />
              </div>
            </div>
          </div>
        </div>

      </div>
    </div>
  </div>
</template>
<script>
import commentAPI from "@/api/comment";
import discussAPI from "@/api/discuss";
export default {
  data() {
    return {
      commentList: [],
      discussData: {},
      form: {
        comment_content: "",
        discuss_id: this.$route.query.discussId,
      },
      exit:false
    };
  },

  methods: {
    fetchData() {
      discussAPI
        .getDiscussById(this.$route.query.discussId)
        .then((response) => {
          const resp = response.data;
          if (resp.flag) {
            this.discussData = resp.data;
          }
          commentAPI
            .getCommentListByDiscussId(this.$route.query.discussId)
            .then((response2) => {
              const resp2 = response2.data;
              if (resp2.flag) {
                this.commentList = resp2.data;
                if(this.commentList.length>0)
                {
                  this.exit=true
                }
              }
            });
        });
    },
    addComment() {
      commentAPI.addComment(this.form).then((response) => {
        const resp = response.data;
        if (resp.flag) {
          this.fetchData();
          this.$message({
            type: "success",
            message: resp.message,
          });
        } else {
          this.$message.error(resp.message);
        }
      });
    },
  },
  created() {
    this.fetchData();
  },
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