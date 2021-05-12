import myaxios from '@/utils/myaxios'
const qs = require("querystring");
export default {
    virus() {
        return myaxios({
            url: '/Map/virus',
            method: 'get'
        })
    }
}