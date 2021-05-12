import myaxios from '@/utils/myaxios'
const qs = require("querystring");
export default {
    getWorkGroup() {
        return myaxios({
            url: `/Work/getWorkGroup`,
            method: 'get'
        })
    },

}