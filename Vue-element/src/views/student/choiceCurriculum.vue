<template>
  <div>
    <div id="myBody">
      <div class="box1">
        <i class="el-icon-warning-outline myi"></i>
        使用手册：这里可以放一些数据
      </div>
      <div class="box2">
        <el-button
          @click="selctCurriculum(multipleSelection)"
          type="primary"
          size="small"
          >选课</el-button
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
        <!-- <div style="margin-top: 20px">
          <el-button @click="toggleSelection([1, 2])"
            >切换第二、第三行的选中状态</el-button
          >
          <el-button @click="toggleSelection()">取消选择</el-button>
        </div> -->
        <el-table
          @selection-change="handleSelectionChange"
          ref="multipleTable"
          :data="curriculumListData"
          stripe
          style="width: 100%"
        >
          <el-table-column type="selection" width="55" show-overflow-tooltip>
          </el-table-column>
          <el-table-column prop="id" label="课程ID" width="100">
          </el-table-column>
          <el-table-column prop="curriculum_name" label="课程名">
          </el-table-column>
          <el-table-column prop="teacher_id" label="教师ID"> </el-table-column>

          <el-table-column prop="createdate" label="开课时间">
          </el-table-column>

          <el-table-column label="操作">
            <template slot-scope="scope">
              <el-link @click="selctCurriculum([scope.row.id])" type="primary"
                >申请选课
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
</style>
<script>
import curriculumApi from "@/api/curriculum.js";
export default {
  methods: {
    selctCurriculum(idList) {
      curriculumApi.chooseCurriculumByIdList(idList).then((response) => {
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
      // if (rows) {
      //   rows.forEach((row) => {
      //     this.$refs.multipleTable.toggleRowSelection(row);
      //   });
      // } else {
      this.$refs.multipleTable.clearSelection();
      // }
    },
    fetchData() {
      curriculumApi.getStudentCurriculumList().then((response) => {
        const resp = response.data;
        if (resp.flag) {
          this.curriculumList = resp.data;
        }

        curriculumApi.getCurriculumList().then((response) => {
          const resp = response.data;
          if (resp.flag) {
            this.curriculumListAll = resp.data;
          }

          this.curriculumListData = this.modifyData(
            this.curriculumListAll,
            this.curriculumList
          );
        });
      });
    },
    handleSizeChange(val) {
      console.log(`每页 ${val} 条`);
    },
    handleCurrentChange(val) {
      console.log(`当前页: ${val}`);
    },
    modifyData(arr1, arr2) {
      for (var i = arr1.length - 1; i >= 0; i--) {
        var a = arr1[i];
        for (var j = arr2.length - 1; j >= 0; j--) {
          var b = arr2[j];
          if (a.id == b.id) {
            arr1.splice(i, 1);
            arr2.splice(j, 1);
            break;
          }
        }
      }
      return arr1;
    },
  },
  created() {
    this.fetchData();
  },
  data() {
    return {
      curriculumList: [],
      curriculumListAll: [],
      curriculumListData: [],
      currentPage1: 5,
      currentPage2: 5,
      currentPage3: 5,
      currentPage4: 4,
      multipleSelection: [],
    };
  },
};
</script>