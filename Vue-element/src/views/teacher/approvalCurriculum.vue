<template>
  <div>
    <div id="myBody">
      <div class="box1">
        <i class="el-icon-warning-outline myi"></i>
        使用手册：这里可以放一些数据
      </div>
      <div class="box2">
        <el-button
          @click="selctCurriculum(multipleSelection, 1)"
          type="primary"
          size="small"
          >全部同意</el-button
        >
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
          @selection-change="handleSelectionChange"
          ref="multipleTable"
          :data="curriculumList"
          stripe
          style="width: 100%"
        >
          <el-table-column type="selection" width="55" show-overflow-tooltip>
          </el-table-column>
          <el-table-column prop="id" label="ID" width="100"> </el-table-column>
          <el-table-column prop="student_id" label="学生ID"> </el-table-column>
          <el-table-column prop="curriculum_id" label="课程ID">
          </el-table-column>

          <el-table-column prop="is_result" label="通知结果"> </el-table-column>

          <el-table-column label="操作">
            <template slot-scope="scope">
              <el-link
                class="mar"
                @click="selctCurriculum([scope.row.id], 1)"
                type="primary"
                >同意
              </el-link>
              <el-link
                class="mar"
                @click="selctCurriculum([scope.row.id], 0)"
                type="primary"
                >拒绝
              </el-link>
            </template>
          </el-table-column>
        </el-table>
        <el-pagination
          @size-change="handleSizeChange"
          @current-change="handleCurrentChange"
          :current-page="currentPage4"
          :page-sizes="[100, 200, 300, 400]"
          :page-size="100"
          layout="total, sizes, prev, pager, next, jumper"
          :total="400"
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
.mar {
  margin-left: 10px;
  margin-right: 10px;
}
</style>
<script>
import curriculumApi from "@/api/curriculum.js";
export default {
  methods: {
    selctCurriculum(idList, is_result) {
      curriculumApi
        .handleCurriculumByIdList(idList, is_result)
        .then((response) => {
          const resp = response.data;
          if (resp.flag) {
            this.$message({
              type: "success",
              message: resp.message,
            });
          } else {
            this.$message.error(resp.message);
          }
          this.toggleSelection();
          this.multipleSelection = [];
          this.fetchData();
        });
    },
    handleSelectionChange(val) {
      this.multipleSelection = [];
      val.forEach((item) => {
        this.multipleSelection.push(item.id);
      });
    },
    toggleSelection() {
      this.$refs.multipleTable.clearSelection();
    },
    fetchData() {
      curriculumApi.teacherCurriculumApproval().then((response) => {
        const resp = response.data;
        if (resp.flag) {
          this.curriculumList = resp.data;
        }
      });
    },
    handleSizeChange(val) {
      console.log(`每页 ${val} 条`);
    },
    handleCurrentChange(val) {
      console.log(`当前页: ${val}`);
    },
  },
  created() {
    this.fetchData();
  },
  data() {
    return {
      curriculumList: [],
      currentPage1: 5,
      currentPage2: 5,
      currentPage3: 5,
      currentPage4: 4,
      multipleSelection: [],
    };
  },
};
</script>