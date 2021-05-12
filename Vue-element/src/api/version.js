import myaxios from '@/utils/myaxios'
const qs = require("querystring");
export default {
    getVersionList() {
        return myaxios({
            url: '/Version/GetVersionList',
            method: 'get'
        })
    },
}