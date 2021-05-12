import myaxios from '@/utils/myaxios'
const qs = require("querystring");
export default {
    getStudentCurriculumList() {
        return myaxios({
            url: '/Curriculum/GetStudentCurriculumList',
            method: 'get'
        })
    },
    getCurriculumList() {
        return myaxios({
            url: '/Curriculum/GetCurriculumList',
            method: 'get'
        })
    },
    chooseCurriculumByIdList(IdList) {
        return myaxios({
            url: '/Curriculum/ChooseCurriculumByIdList',
            method: 'post',
            data: IdList
        })
    },
    teacherCurriculumApproval() {
        return myaxios({
            url: '/Curriculum/TeacherCurriculumApproval',
            method: 'get'
        })
    },
    handleCurriculumByIdList(IdList, is_result) {
        return myaxios({
            url: `/Curriculum/HandleCurriculumByIdList?is_result=${is_result}`,
            method: 'post',
            data: IdList
        })
    },
    getTeacherCurriculumLst() {
        return myaxios({
            url: '/Curriculum/GetTeacherCurriculumLst',
            method: 'get'
        })
    },
    addCurriculum(curriculumData) {
        return myaxios({
            url: `/Curriculum/addCurriculum`,
            method: 'post',
            data: curriculumData,
        })
    },
    delCurriculum(id) {
        return myaxios({
            url: `/Curriculum/delCurriculum?id=${id}`,
            method: 'get',
        })
    }

}