import myaxios from '@/utils/myaxios'
const qs = require("querystring");
export default {
    getStudent() {
        return myaxios({
            url: '/Student/GetStudent',
            method: 'get'
        })
    },
    updateStudent(form) {
        return myaxios({
            url: `/Student/updateStudent`,
            method: 'post',
            data: form,
        })
    }
}