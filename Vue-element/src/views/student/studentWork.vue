<template>
  <div>
    <div id="myBody">
      <div class="box1">
        <i class="el-icon-warning-outline myi"></i>
        使用手册：这里可以放一些数据
      </div>
      <div class="box2">
        <el-button type="primary" size="small">选择作业</el-button>
        <el-button @click="showby(true)" size="small" plain>升序</el-button>
        <el-button @click="showby(false)" size="small" plain>降序</el-button>
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
          <el-table-column prop="id" label="课程ID" width="100">
          </el-table-column>
          <el-table-column prop="student_id" label="学生ID"> </el-table-column>
          <el-table-column prop="work_id" label="作业ID"> </el-table-column>
          <el-table-column prop="is_complete" label="是否完成">
          </el-table-column>
          <el-table-column prop="time_complete" label="完成时间">
          </el-table-column>
          <el-table-column prop="work_score" label="作业分数">
            <template slot-scope="scope">
              <span>{{ scope.row.work_score | scoreFilter }}</span>
            </template>
          </el-table-column>
          <el-table-column prop="work_score_time" label="批改时间">
          </el-table-column>
          <el-table-column label="操作">
            <template slot-scope="scope">
              <el-link @click="selctWork(scope.row.work_id)" type="primary"
                >查看作业
              </el-link>
            </template>
          </el-table-column>
        </el-table>
        <el-pagination
          background
          @size-change="handleSizeChange"
          @current-change="handleCurrentChange"
          :current-page="currentPage"
          :page-sizes="[5, 10, 20, 50]"
          :page-size="pageSize"
          layout="total, sizes, prev, pager, next, jumper"
          :total="total"
        >
        </el-pagination>
      </div>
    </div>
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
</style>
<script>
import workAPI from "@/api/work";
export default {
  methods: {
    selctWork(workId) {
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
          if(resp.data==3)
          {
              this.$router.push({ path: "/imageInfo", query: { id: workId } });
          }
        }
      });
    },
    showby(bl) {
      this.by = bl;
      this.fetchData();
    },
    fetchData() {
      workAPI
        .getStudentWorkList(this.currentPage, this.pageSize, this.by)
        .then((response) => {
          const resp = response.data;
          if (resp.flag) {
            this.workList = resp.data;
            this.total = resp.num;
          }
        });
    },
    handleSizeChange(size) {
      this.pageSize = size;
      this.fetchData();
    },
    handleCurrentChange(currentPage) {
      this.currentPage = currentPage;
      this.fetchData();
    },
  },
  created() {
    this.fetchData();
  },
  filters: {
    scoreFilter(num) {
      if (num == -1) {
        return "暂未批改";
      } else {
        return num;
      }
    },
    completeFilter(num) {
      if (num == -1) {
        return "暂未批改";
      } else {
        return num;
      }
    },
  },
  data() {
    return {
      workList: [],
      total: 0,
      currentPage: 1,
      pageSize: 10,
      by: true,
    };
  },
};
</script>