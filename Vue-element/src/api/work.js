import myaxios from '@/utils/myaxios'
const qs = require("querystring");
export default {
    getWorklistByCurriculumId(curriculumId) {
        return myaxios({
            url: `/Work/GetWorklistByCurriculumId?curriculumId=${curriculumId}`,
            method: 'get'
        })
    },
    getWorkByWorkId(workId) {
        return myaxios({
            url: `/Work/GetWorkByWorkId?workId=${workId}`,
            method: 'get'
        })
    },
    getApprovalWorkList() {
        return myaxios({
            url: `/Work/GetApprovalWorkList`,
            method: 'get'
        })
    },
    approvalWork(form) {
        return myaxios({
            url: `/Work/ApprovalWork`,
            method: 'post',
            data: qs.stringify(form)
        })
    },
    getStudentWorkList(page, size, by) {
        return myaxios({
            url: `/Work/GetStudentWorkList`,
            method: 'post',
            data: qs.stringify({
                page: page,
                size: size,
                by: by
            })
        })
    },
    getWorkTypeByWorkId(workId) {
        return myaxios({
            url: `/Work/getWorkTypeByWorkId?workId=${workId}`,
            method: 'get',
        })
    },
    addWorkByAjax(form) {
        return myaxios({
            url: `/Work/addWorkByAjax`,
            method: 'post',
            data: form
        })
    },
    sendImg(myimg, id) {
        //提交图片
        return myaxios({
            url: `/Work/sendImg`,
            method: "post",
            headers: { "content-type": "application/x-www-form-urlencoded" },
            data: qs.stringify({ myimg: myimg, id: id })
        });
    },
    updateWork(form) {
        return myaxios({
            url: `/Work/updateWork`,
            method: 'post',
            data: form
        })
    },
    delWorkByWorkId(workId) {
        return myaxios({
            url: `/Work/delWorkByWorkId?workId=${workId}`,
            method: 'get',
        })
    },
    getMyWorkByWorkId(workId) {
        return myaxios({
            url: `/Work/getMyWorkByWorkId?workId=${workId}`,
            method: 'get',
        })
    }
}