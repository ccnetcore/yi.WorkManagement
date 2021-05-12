<template>
  <div>
    <div id="myBody">
      <div class="box1">
        <i class="el-icon-warning-outline myi"></i>
        使用手册：这里可以放一些数据
      </div>
      <div class="box2">
        <el-button type="primary" size="small">其他功能</el-button>
        <el-button size="small" plain>其他</el-button>
        <el-button size="small" plain>其他</el-button>
        <el-button size="small" plain>其他</el-button>
        <el-button size="small" plain>其他</el-button>
        <el-button size="small" plain>其他</el-button>
        <el-button size="small" plain>其他</el-button>
        <el-button size="small" plain>其他功能</el-button>
      </div>
      <div class="box3">
        <el-input
          size="mini"
          placeholder="输入数据"
          style="width: 60%"
          suffix-icon="el-icon-search"
        ></el-input>
      </div>
      <div class="box4">
        <el-table
          ref="multipleTable"
          :data="workList"
          stripe
          style="width: 100%"
        >
          <el-table-column prop="id" label="id" width="100"> </el-table-column>
          <el-table-column prop="student_id" label="学生ID"> </el-table-column>
          <el-table-column prop="work_id" label="作业ID"> </el-table-column>

          <el-table-column prop="time_complete" label="完成时间">
          </el-table-column>

          <el-table-column label="操作">
            <template slot-scope="scope">
              <el-link
                class="mar"
                @click="look(scope.row.work_id)"
                type="primary"
                >查看
              </el-link>
              <el-link
                class="mar"
                @click="approval(scope.row.id)"
                type="primary"
                >批改
              </el-link>
            </template>
          </el-table-column>
        </el-table>
        <el-pagination
          :current-page="currentPage4"
          :page-sizes="[100, 200, 300, 400]"
          :page-size="100"
          layout="total, sizes, prev, pager, next, jumper"
          :total="400"
        >
        </el-pagination>
      </div>
    </div>

    <!--打开嵌套表单的 Dialog-->

    <el-dialog title="批改作业" :visible.sync="dialogFormVisible" width="600px">
      <el-form label-width="80px" ref="form">
        <el-form-item label="得分">
          <el-input-number
            v-model="Data.score"
            :min="0"
            :max="100"
          ></el-input-number>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="dialogFormVisible = false">取 消</el-button>
        <el-button type="primary" @click="approvalWork()">确 定</el-button>
      </div>
    </el-dialog>
  </div>
</template>
<style scoped>
.box1 {
  background-color: #d5e7ff;
  height: 48px;
  margin-bottom: 20px;
  padding: 14px;
  color: #002da0;
  font-size: 13px;
}
.box2 {
  text-align: left;
}
.box3 {
  text-align: left;
  margin-top: 15px;
  margin-bottom: 15px;
}
.box4 {
  box-shadow: 0 2px 12px 0 rgba(0, 0, 0, 0.1);
  padding-bottom: 10px;
  background-color: #ffffff;
}
.el-pagination {
  margin: 10px;
}
#myBody {
  padding: 20px;
}
.boxColor {
  background-color: #ffffff;
}
.myi {
  margin-left: 10px;
  margin-right: 10px;
  width: 30px;
  height: 30px;
  size: 30px;
}
.mar {
  margin-left: 10px;
  margin-right: 10px;
}
</style>
<script>
import workAPI from "@/api/work";
export default {
  methods: {
    approvalWork() {
      workAPI.approvalWork(this.Data).then((response) => {
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
    look(workId) {
      workAPI.getWorkTypeByWorkId(workId).then((response) => {
        const resp = response.data;
        if (resp.flag) {
          if (resp.data == 1) {
            this.$router.push({ path: "/fileInfo", query: { id: workId } });
          }
          if (resp.data == 2) {
            this.$router.push({
              path: "/examinationInfo",
              query: { id: workId },
            });
          }
        }
      });
    },
    approval(id) {
      this.Data.studentworkId = id;
      this.dialogFormVisible = true;
    },
    fetchData() {
      workAPI.getApprovalWorkList().then((response) => {
        const resp = response.data;
        if (resp.flag) {
          this.workList = resp.data;
        }
      });
    },
  },
  mounted() {
    this.base_api = process.env.VUE_APP_BASE_API;
  },
  created() {
    this.fetchData();
  },
  data() {
    return {
      workList: [],
      dialogFormVisible: false,
      Data: {
        studentworkId: -1,
        score: 90,
      },
    };
  },
};
</script>