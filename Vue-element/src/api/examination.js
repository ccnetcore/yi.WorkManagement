import myaxios from '@/utils/myaxios'
const qs = require("querystring");
export default {
    getExaminationListById(workid) {
        return myaxios({
            url: `/Examination/getExaminationList?workid=${workid}`,
            method: 'get'
        })
    },
    subExamination1(choice_questionList) {
        return myaxios({
            url: `/Examination/subExamination1`,
            method: 'post',
            data: choice_questionList
        })
    },
    subExamination2(judgment_questionList) {
        return myaxios({
            url: `/Examination/subExamination2`,
            method: 'post',
            data: judgment_questionList
        })
    },
    subExamination3(fill_questionList, studentworkId) {
        return myaxios({
            url: `/Examination/subExamination3?studentworkid=${studentworkId}`,
            method: 'post',
            data: fill_questionList
        })
    },
    addExamination1(choice_questionList) {
        return myaxios({
            url: `/Examination/addExamination1`,
            method: 'post',
            data: choice_questionList
        })
    },
    addExamination2(judgment_questionList) {
        return myaxios({
            url: `/Examination/addExamination2`,
            method: 'post',
            data: judgment_questionList
        })
    },
    addExamination3(fill_questionList) {
        return myaxios({
            url: `/Examination/addExamination3`,
            method: 'post',
            data: fill_questionList
        })
    },
}